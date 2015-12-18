using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class OrderGateway : IServiceGateway<OrderDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(OrderDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/orders", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/orders/" + id).Result;
            return response;
        }

        public OrderDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orders/" + id).Result;
            var order = response.Content.ReadAsAsync<OrderDTO>().Result;
            return order;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orders/").Result;
            var orders = response.Content.ReadAsAsync<IEnumerable<OrderDTO>>().Result;
            return orders;
        }

        public HttpResponseMessage Update(OrderDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/orders/" + t.Id, t).Result;
            return response;
        }
    }
}
