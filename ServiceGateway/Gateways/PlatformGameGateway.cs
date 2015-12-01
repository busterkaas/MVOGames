using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class PlatformGameGateway : IServiceGateway<PlatformGame>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(PlatformGame t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/platformgames", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/platformgames/" + id).Result;
            return response;
        }

        public PlatformGame Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platformgames/" + id).Result;
            var game = response.Content.ReadAsAsync<PlatformGame>().Result;
            return game;
        }

        public IEnumerable<PlatformGame> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platformgames/").Result;
            var game = response.Content.ReadAsAsync<IEnumerable<PlatformGame>>().Result;
            return game;
        }

        public HttpResponseMessage Update(PlatformGame t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/platformgames/" + t.Id, t).Result;
            return response;
        }
    }
}
