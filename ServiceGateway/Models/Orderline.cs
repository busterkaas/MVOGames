using System;

namespace ServiceGateway.Models
{
    public class Orderline
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public int PlatformGameId { get; set; }
        public int OrderId { get; set; }
        public virtual PlatformGame PlatformGame { get; set; }
        public virtual Order Order { get; set; }

    }
}
