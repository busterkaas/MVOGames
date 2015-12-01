using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class UserGateway : IServiceGateway<User>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(User t)
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

        public User Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/users/" + id).Result;
            var user = response.Content.ReadAsAsync<User>().Result;
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/users/").Result;
            var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            return users;
        }

        public HttpResponseMessage Update(User t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/users/" + t.Id, t).Result;
            return response;
        }
    }
}