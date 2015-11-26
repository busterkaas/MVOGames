using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Models
{
    public class OrderlineDTO
    {
        public int Id { get; set; }
        private int Amount { get; set; }
        public decimal Discount { get; set; }
        public int GameId { get; set; }
        public int OrderId { get; set; }
    }
}
