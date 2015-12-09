using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class SuggestionUsersGateway : IServiceGateway<SuggestionUsers>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(SuggestionUsers t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/suggestionusers", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/suggestionusers/" + id).Result;
            return response;
        }

        public SuggestionUsers Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/suggestionusers/" + id).Result;
            var suggestionUsers = response.Content.ReadAsAsync<SuggestionUsers>().Result;
            return suggestionUsers;
        }

        public IEnumerable<SuggestionUsers> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/suggestionusers/").Result;
            var suggestionUsers = response.Content.ReadAsAsync<IEnumerable<SuggestionUsers>>().Result;
            return suggestionUsers;
        }

        public HttpResponseMessage Update(SuggestionUsers t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/suggestionusers/" + t.Id, t).Result;
            return response;
        }
    }
}
