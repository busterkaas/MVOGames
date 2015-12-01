using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Models;

namespace ServiceGateway.Gateways
{
    public class OrderGateway : IServiceGateway<Order>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Order t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/orders", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/order/" + id).Result;
            return response;
        }

        public Order Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orders/" + id).Result;
            var order = response.Content.ReadAsAsync<Order>().Result;
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orders/").Result;
            var orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            return orders;
        }

        public HttpResponseMessage Update(Order t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/orders/" + t.Id, t).Result;
            return response;
        }
    }
}
