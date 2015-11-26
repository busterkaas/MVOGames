using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

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

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/games/" + id).Result;
            return response;
        }

        public GameDTO Get(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/games/" + id).Result;
            var gameDTO = response.Content.ReadAsAsync<GameDTO>().Result;
            return gameDTO;
        }

        public IEnumerable<GameDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/gameDTO/").Result;
            var gameDTO = response.Content.ReadAsAsync<IEnumerable<GameDTO>>().Result;
            return gameDTO;
        }

        public HttpResponseMessage Update(GameDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/gameDTO/" + t.Id, t).Result;
            return response;
        }
    }
}
