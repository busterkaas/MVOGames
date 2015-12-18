using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class SuggestionUsersGateway : IServiceGateway<SuggestionUsersDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(SuggestionUsersDTO t)
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

        public SuggestionUsersDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/suggestionusers/" + id).Result;
            var suggestionUsers = response.Content.ReadAsAsync<SuggestionUsersDTO>().Result;
            return suggestionUsers;
        }

        public IEnumerable<SuggestionUsersDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/suggestionusers/").Result;
            var suggestionUsers = response.Content.ReadAsAsync<IEnumerable<SuggestionUsersDTO>>().Result;
            return suggestionUsers;
        }

        public HttpResponseMessage Update(SuggestionUsersDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/suggestionusers/" + t.Id, t).Result;
            return response;
        }
    }
}
