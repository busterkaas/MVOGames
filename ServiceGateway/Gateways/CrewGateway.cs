using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class CrewGateway : IServiceGateway<Crew>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Crew t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/crews", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/crews/" + id).Result;
            return response;
        }

        public Crew Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crews/" + id).Result;
            var crew = response.Content.ReadAsAsync<Crew>().Result;
            return crew;
        }

        public IEnumerable<Crew> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crews/").Result;
            var crews = response.Content.ReadAsAsync<IEnumerable<Crew>>().Result;
            return crews;
        }

        public HttpResponseMessage Update(Crew t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/crews/" + t.Id, t).Result;
            return response;
        }
    }
}
