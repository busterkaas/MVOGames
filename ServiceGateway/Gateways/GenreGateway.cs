using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class GenreGateway : IServiceGateway<GenreDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(GenreDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/genres", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/genres/" + id).Result;
            return response;
        }

        public GenreDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/genres/" + id).Result;
            var genre = response.Content.ReadAsAsync<GenreDTO>().Result;
            return genre;
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/genres/").Result;
            var genres = response.Content.ReadAsAsync<IEnumerable<GenreDTO>>().Result;
            return genres;
        }

        public HttpResponseMessage Update(GenreDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/genres/" + t.Id, t).Result;
            return response;
        }
    }
}
