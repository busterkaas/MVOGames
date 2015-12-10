using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class CrewApplicationGateway : IServiceGateway<CrewApplication>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(CrewApplication t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/crewapplications", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/crewapplications/" + id).Result;
            return response;
        }

        public CrewApplication Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crewapplications/" + id).Result;
            var crewsapplication = response.Content.ReadAsAsync<CrewApplication>().Result;
            return crewsapplication;
        }

        public IEnumerable<CrewApplication> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crewapplications/").Result;
            var crewsapplications = response.Content.ReadAsAsync<IEnumerable<CrewApplication>>().Result;
            return crewsapplications;
        }

        public HttpResponseMessage Update(CrewApplication t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/crewapplications/" + t.Id, t).Result;
            return response;
        }
    }
}
