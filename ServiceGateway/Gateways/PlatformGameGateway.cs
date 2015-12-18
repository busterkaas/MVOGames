using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class PlatformGameGateway : IServiceGateway<PlatformGameDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(PlatformGameDTO t)
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

        public PlatformGameDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platformgames/" + id).Result;
            var game = response.Content.ReadAsAsync<PlatformGameDTO>().Result;
            return game;
        }

        public IEnumerable<PlatformGameDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platformgames/").Result;
            var game = response.Content.ReadAsAsync<IEnumerable<PlatformGameDTO>>().Result;
            return game;
        }

        public HttpResponseMessage Update(PlatformGameDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/platformgames/" + t.Id, t).Result;
            return response;
        }
    }
}
