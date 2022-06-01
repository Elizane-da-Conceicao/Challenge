using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotBlip.Api.Services
{
    public class Comunicacao <T> where T : class
    {
        static readonly HttpClient client = new HttpClient();
        public T Comunicar(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            client.DefaultRequestHeaders.Add("User-Agent", "request");

            var response = client.Send(request);
            var responseBody = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody.Result.ToString());

        }
    }
}
