
using DTOModels.Models;
using MVOGamesUI.Areas.User.Models;
using MVOGamesUI.Areas.User.Models.ShoppingCartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class UserCartPayment
    {
        public UserCartPayment(UserDTO user, ShoppingCartModel cart, FakePayment payment)
        {
            User = user;
            CartModel = cart;
            FakePayment = payment;
        }
        public UserDTO User { get; set; }
        public ShoppingCartModel CartModel { get; set; }
        public FakePayment FakePayment { get; set; }
    }
}