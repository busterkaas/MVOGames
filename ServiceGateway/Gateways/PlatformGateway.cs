using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class PlatformGateway : IServiceGateway<Platform>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Platform t)
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

        public Platform Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platforms/" + id).Result;
            var platform = response.Content.ReadAsAsync<Platform>().Result;
            return platform;
        }

        public IEnumerable<Platform> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/platforms/").Result;
            var platforms = response.Content.ReadAsAsync<IEnumerable<Platform>>().Result;
            return platforms;
        }

        public HttpResponseMessage Update(Platform t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/platforms/" + t.Id, t).Result;
            return response;
        }
    }
}
