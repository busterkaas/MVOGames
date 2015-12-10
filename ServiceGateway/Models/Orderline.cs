using System;

namespace ServiceGateway.Models
{
    public class Orderline
    {
        public int Id { get; set; }
        private int amount { get; set; }
        public int Amount
        {
            get { return amount; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Amount must be above 0");
                }
                amount = value;
            }
        }
        public decimal Discount { get; set; }
        public int PlatformGameId { get; set; }
        public int OrderId { get; set; }
        public virtual PlatformGame PlatformGame { get; set; }
        public virtual Order Order { get; set; }

    }
}
