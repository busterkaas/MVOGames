using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class CrewGameSuggestionGateway : IServiceGateway<CrewGameSuggestionDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(CrewGameSuggestionDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/crewgamesuggestions", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/crewgamesuggestions/" + id).Result;
            return response;
        }

        public CrewGameSuggestionDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crewgamesuggestions/" + id).Result;
            var crewgamesuggestion = response.Content.ReadAsAsync<CrewGameSuggestionDTO>().Result;
            return crewgamesuggestion;
        }

        public IEnumerable<CrewGameSuggestionDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/crewgamesuggestions/").Result;
            var crewgamesuggestions = response.Content.ReadAsAsync<IEnumerable<CrewGameSuggestionDTO>>().Result;
            return crewgamesuggestions;
        }

        public HttpResponseMessage Update(CrewGameSuggestionDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/crewgamesuggestions/" + t.Id, t).Result;
            return response;
        }
    }
}
