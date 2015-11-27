using System;
using System.Collections.Generic;

namespace ServiceGateway.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Orderline> Orderlines { get; set; }
    }
}
