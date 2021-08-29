using Newtonsoft.Json;
using SampleForHttp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleForHttp.Services
{
    public class PlayerService
    {
        private readonly string _token;

        public PlayerService(string token)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public async Task Add(Player player)
        {
            string serializedPlayer = JsonConvert.SerializeObject(player);

            var content = new StringContent(serializedPlayer, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);

                HttpResponseMessage responseMessage = await client.PostAsync("http://dev.trainee.dex-it.ru/api/Player/Add", content);
                var reult = await responseMessage.Content.ReadAsStringAsync();
                responseMessage.EnsureSuccessStatusCode();
            }
        }

        public async Task<PlayerResponce> GetPlayers()
        {
            HttpResponseMessage responceMessage;
            PlayerResponce playerResponce;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
                responceMessage = await client.GetAsync("http://dev.trainee.dex-it.ru/api/Player/GetPlayers");

                responceMessage.EnsureSuccessStatusCode();

                string serializedMessage = await responceMessage.Content.ReadAsStringAsync();
                playerResponce = JsonConvert.DeserializeObject<PlayerResponce>(serializedMessage);
            }

            return playerResponce;
        }
    }
}
