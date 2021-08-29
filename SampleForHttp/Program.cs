using SampleForHttp.Models;
using SampleForHttp.Services;
using System;
using System.Threading.Tasks;

namespace SampleForHttp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoi0JHQvtCz0LTQsNC9IiwidGVuYW50I" +
                "joiNzI5IiwibmJmIjoxNjI5OTkxNjcwLCJleHAiOjE2MzAwNzgwNzAsImlzcyI6IlRlc3QtQmFja2VuZC0xIiwiYX" +
                "VkIjoiQmFza2V0QmFsbENsdWJTYW1wbGUifQ.6YRwKYEvr2isDnWdXqMyCrrEYPtEd657pdKNHP1lpzg";
            TeamService teamService = new TeamService(token);
            PlayerService playerService = new PlayerService(token);

            Team team = new Team()
            {
                Name = "Barcelona",
                FoundationYear = 2003,
                Division = "abc",
                ImageUrl = "myImage"
            };

            await teamService.Add(team);

            TeamResponce teamResponce = await teamService.GetTeams();

            Player player = new Player()
            {
                Name = "Vova",
                Number = 18,
                Position = "Guard",
                Team = 826,
                Birthday = new DateTime(2003),
                Height = 100,
                Weight = 100,
                AvatarUrl = "avatarImage",
                TeamName = team.Name
            };

            await playerService.Add(player);

            PlayerResponce playerResponce = await playerService.GetPlayers();
        }
    }
}
