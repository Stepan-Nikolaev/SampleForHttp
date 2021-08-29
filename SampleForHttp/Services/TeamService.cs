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
    public class TeamService
    {
        private readonly string _token;

        public TeamService(string token)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public async Task Add(Team team)
        {
            string serializedTeam = JsonConvert.SerializeObject(team);

            var content = new StringContent(serializedTeam, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);

                await client.PostAsync("http://dev.trainee.dex-it.ru/api/Team/Add", content);
            }
        }

        public async Task<TeamResponce> GetTeams()
        {
            HttpResponseMessage responceMessage;
            TeamResponce teamResponce;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
                responceMessage = await client.GetAsync("http://dev.trainee.dex-it.ru/api/Team/GetTeams");

                responceMessage.EnsureSuccessStatusCode();

                string serializedMessage = await responceMessage.Content.ReadAsStringAsync();
                teamResponce = JsonConvert.DeserializeObject<TeamResponce>(serializedMessage);
            }

            return teamResponce;
        }
    }
}
