using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;

namespace ServiceGateway.Gateways
{
    public class UserGateway : IServiceGateway<UserDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(UserDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/users", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/users/" + id).Result;
            return response;
        }

        public UserDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/users/" + id).Result;
            var user = response.Content.ReadAsAsync<UserDTO>().Result;
            return user;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/users/").Result;
            var users = response.Content.ReadAsAsync<IEnumerable<UserDTO>>().Result;
            return users;
        }

        public HttpResponseMessage Update(UserDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/users/" + t.Id, t).Result;
            return response;
        }
    }
}