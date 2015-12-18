using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class GameGateway : IServiceGateway<GameDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(GameDTO t)
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

        public GameDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/games/" + id).Result;
            var game = response.Content.ReadAsAsync<GameDTO>().Result;
            return game;
        }

        public IEnumerable<GameDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/games/").Result;
            var games = response.Content.ReadAsAsync<IEnumerable<GameDTO>>().Result;
            return games;
        }

        public HttpResponseMessage Update(GameDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/games/" + t.Id, t).Result;
            return response;
        }
    }
}
