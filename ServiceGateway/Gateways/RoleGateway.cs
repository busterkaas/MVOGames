using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class RoleGateway : IServiceGateway<RoleDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(RoleDTO t)
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

        public RoleDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/roles/" + id).Result;
            var role = response.Content.ReadAsAsync<RoleDTO>().Result;
            return role;
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/roles/").Result;
            var roles = response.Content.ReadAsAsync<IEnumerable<RoleDTO>>().Result;
            return roles;
        }

        public HttpResponseMessage Update(RoleDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/roles/" + t.Id, t).Result;
            return response;
        }
    }
}

