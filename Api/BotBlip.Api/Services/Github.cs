using BotBlip.Api.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotBlip.Api.Services
{
    public class Github
    {
        private static Comunicacao<List<Repos>> comunicaGithub = new();
        private static Comunicacao<Avatar> comunicaAvatar = new();

        public List<Repos> GetRepositories()
        {
            string url = "https://api.github.com/users/takenet/repos";
            string urlAvatar = "https://api.github.com/users/takenet";
            var repos = comunicaGithub.Comunicar(url);
            var avatar = comunicaAvatar.Comunicar(urlAvatar);
            
            return GetFiveOldestRepositories(repos, avatar);
                        
        }

        
        public List<Repos> GetFiveOldestRepositories(List<Repos> repositories, Avatar avatar) 
        {

            List<Repos> old = new List<Repos>();
            DateTime data_old = new DateTime();

            for (int i = 0; i < 5; i++)
            {
                int id = 0;

                foreach (var item in repositories)
                {
                    if (item.Language != null && item.Language.Equals("C#"))
                    {
                        int compare = DateTime.Compare(item.Created_at, data_old);
                        if(compare < 0 || id == 0)
                        {
                            data_old = item.Created_at;
                            id = item.Id;
                            item.Avatar = avatar;
                        } 
                    }
                }
                old.Add(repositories.Find(d => d.Id == id));
                repositories.Remove(repositories.Find(d => d.Id == id));

            }
            return old;
        }

    }
}
