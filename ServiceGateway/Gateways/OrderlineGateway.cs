using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class OrderlineGateway : IServiceGateway<Orderline>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Orderline t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/orderlines", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/orderlines/" + id).Result;
            return response;
        }

        public Orderline Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orderlines/" + id).Result;
            var orderline = response.Content.ReadAsAsync<Orderline>().Result;
            return orderline;
        }

        public IEnumerable<Orderline> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orderlines/").Result;
            var orderlines = response.Content.ReadAsAsync<IEnumerable<Orderline>>().Result;
            return orderlines;
        }

        public HttpResponseMessage Update(Orderline t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/orderlines/" + t.Id, t).Result;
            return response;
        }
    }
}
