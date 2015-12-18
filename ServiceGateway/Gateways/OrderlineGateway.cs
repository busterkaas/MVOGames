using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public class OrderlineGateway : IServiceGateway<OrderlineDTO>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(OrderlineDTO t)
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

        public OrderlineDTO Get(int? id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orderlines/" + id).Result;
            var orderline = response.Content.ReadAsAsync<OrderlineDTO>().Result;
            return orderline;
        }

        public IEnumerable<OrderlineDTO> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orderlines/").Result;
            var orderlines = response.Content.ReadAsAsync<IEnumerable<OrderlineDTO>>().Result;
            return orderlines;
        }

        public HttpResponseMessage Update(OrderlineDTO t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/orderlines/" + t.Id, t).Result;
            return response;
        }
    }
}
