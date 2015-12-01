using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class RoleGateway : IServiceGateway<Role>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Role t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/roles", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/roles/" + id).Result;
            return response;
        }

        public Role Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/roles/" + id).Result;
            var role = response.Content.ReadAsAsync<Role>().Result;
            return role;
        }

        public IEnumerable<Role> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/roles/").Result;
            var roles = response.Content.ReadAsAsync<IEnumerable<Role>>().Result;
            return roles;
        }

        public HttpResponseMessage Update(Role t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/roles/" + t.Id, t).Result;
            return response;
        }
    }
}

