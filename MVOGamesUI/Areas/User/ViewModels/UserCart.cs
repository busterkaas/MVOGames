using MVOGamesUI.Areas.User.Models.ShoppingCartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class UserCart
    {
        public UserCart(ServiceGateway.Models.User user, ShoppingCartModel cart)
        {
            User = user;
            cartModel = cart;
        }
        public ServiceGateway.Models.User User { get; set; }
        public ShoppingCartModel cartModel { get; set; }
    }
}