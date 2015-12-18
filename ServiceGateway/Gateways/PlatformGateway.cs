using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class PlatformGateway : IServiceGateway<PlatformDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(PlatformDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/platforms", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/platforms/" + id).Result;
            return response;
        }

        public PlatformDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platforms/" + id).Result;
            var platform = response.Content.ReadAsAsync<PlatformDTO>().Result;
            return platform;
        }

        public IEnumerable<PlatformDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platforms/").Result;
            var platforms = response.Content.ReadAsAsync<IEnumerable<PlatformDTO>>().Result;
            return platforms;
        }

        public HttpResponseMessage Update(PlatformDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/platforms/" + t.Id, t).Result;
            return response;
        }
    }
}
