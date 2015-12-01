using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class GameGateway : IServiceGateway<Game>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Game t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/games", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/games/" + id).Result;
            return response;
        }

        public Game Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/games/" + id).Result;
            var game = response.Content.ReadAsAsync<Game>().Result;
            return game;
        }

        public IEnumerable<Game> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/games/").Result;
            var games = response.Content.ReadAsAsync<IEnumerable<Game>>().Result;
            return games;
        }

        public HttpResponseMessage Update(Game t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/games/" + t.Id, t).Result;
            return response;
        }
    }
}
