using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.Models.ShoppingCartModels
{
    public class ShoppingCartItem
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public int PlatformGameId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}