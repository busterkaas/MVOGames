using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Gateways
{
    public interface IServiceGateway<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        HttpResponseMessage Create(T t);
        HttpResponseMessage Update(T t);
        HttpResponseMessage Delete(int id);
    }
}
