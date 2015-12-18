
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class CrewApplicationGateway : IServiceGateway<CrewApplicationDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(CrewApplicationDTO t)
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

        public CrewApplicationDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crewapplications/" + id).Result;
            var crewsapplication = response.Content.ReadAsAsync<CrewApplicationDTO>().Result;
            return crewsapplication;
        }

        public IEnumerable<CrewApplicationDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crewapplications/").Result;
            var crewsapplications = response.Content.ReadAsAsync<IEnumerable<CrewApplicationDTO>>().Result;
            return crewsapplications;
        }

        public HttpResponseMessage Update(CrewApplicationDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/crewapplications/" + t.Id, t).Result;
            return response;
        }
    }
}
