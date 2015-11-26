using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Models
{
    public class PlatformGameDTO
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
