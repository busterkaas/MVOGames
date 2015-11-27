using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class GenreGateway : IServiceGateway<Genre>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Genre t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/genres", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/genres/" + id).Result;
            return response;
        }

        public Genre Get(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/genres/" + id).Result;
            var genre = response.Content.ReadAsAsync<Genre>().Result;
            return genre;
        }

        public IEnumerable<Genre> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/genres/").Result;
            var genres = response.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            return genres;
        }

        public HttpResponseMessage Update(Genre t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/genres/" + t.Id, t).Result;
            return response;
        }
    }
}
