using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.OrderLogic;
using ServiceGateway;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.User.Models.ShoppingCartModels
{
    public class ShoppingCartModel : IShoppingCartModel
    {
        CartLogic cl;
        List<PlatformGame> platformGames; 

        public ShoppingCartModel(List<PlatformGame> platformGames )
        {
            cl = new CartLogic();
            this.platformGames = platformGames;
        }
        public IList<ShoppingCartItem> Items { get; set; }
        public void Add(int id)
        {
            ShoppingCartItem cartItem = (from item in Items
                                         where item.PlatformGameId == id
                                         select item).FirstOrDefault();

            if (cartItem == null)
            {
                PlatformGame pGame = platformGames.Find(p => p.Id == id);
                //PlatformGame pGame = facade.GetPlatformGameGateway().Get(id);
                cartItem = new ShoppingCartItem
                {
                    PlatformGameId = pGame.Id,
                    Title = pGame.Game.Title,
                    Platform = pGame.Platform.Name,
                    UnitPrice = pGame.Price,
                    Quantity = 1
                };
                Items.Add(cartItem);
            }
            else
                cartItem.Quantity++;
        }

        public int NoOfItems
        {
            get
            {
                return Items.Sum(item => item.Quantity);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                decimal sum = 0;
                foreach (var item in Items)
                {
                    sum += cl.CalculateTotalPrice(item.Quantity, item.UnitPrice);
                }
                return sum;
            }
        }
    }
}