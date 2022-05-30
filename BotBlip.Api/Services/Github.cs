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
        static readonly HttpClient client = new HttpClient();
        public List<Repos> GetRepositories()
        {
            string url = "https://api.github.com/users/takenet/repos";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            client.DefaultRequestHeaders.Add("User-Agent", "request");

            var response = client.Send(request);
            var responseBody =  response.Content.ReadAsStringAsync();

            var repos = JsonConvert.DeserializeObject<List<Repos>>(responseBody.Result.ToString());
            return GetFiveOldestRepositories(repos);
                        
        }

        public List<Repos> GetFiveOldestRepositories(List<Repos> repositories) 
        {
            List<Repos> old = new List<Repos>();
            DateTime data_old = new DateTime();
            for (int i = 0; i < 5; i++)
            {
                int id = 0;

                foreach (var item in repositories)
                {
                    int compare = DateTime.Compare(item.Created_at, data_old);
                    if(compare < 0 || id == 0)
                    {
                        data_old = item.Created_at;
                        id = item.Id;
                    } 
                }
                old.Add(repositories.Find(d => d.Id == id));
                repositories.Remove(repositories.Find(d => d.Id == id));

            }
            return old;
        }

    }
}
