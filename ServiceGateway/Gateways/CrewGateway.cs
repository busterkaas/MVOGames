using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class CrewGateway : IServiceGateway<CrewDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(CrewDTO t)
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

        public CrewDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crews/" + id).Result;
            var crew = response.Content.ReadAsAsync<CrewDTO>().Result;
            return crew;
        }

        public IEnumerable<CrewDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crews/").Result;
            var crews = response.Content.ReadAsAsync<IEnumerable<CrewDTO>>().Result;
            return crews;
        }

        public HttpResponseMessage Update(CrewDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/crews/" + t.Id, t).Result;
            return response;
        }
    }
}
