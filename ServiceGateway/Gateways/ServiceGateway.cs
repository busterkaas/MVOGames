using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ServiceGateway.Gateways
{
    public class ServiceGateway
    {
        public HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            //string baseAddress = WebConfigurationManager.AppSettings["MVOGames_Rest_BaseAddress"];
            client.BaseAddress = new Uri("http://localhost:40184/");
            //client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
            );
            return client;
        }
    }
}
