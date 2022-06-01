using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotBlip.Api.DTOs
{
    public class Repos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created_at { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public Avatar Avatar { get; set; }
    }
}
