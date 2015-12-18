
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class OrderGames
    {
        private OrderDTO order;
        private List<OrderlineDTO> orderlines;
        private List<PlatformGameDTO> platformgames;
        private List<GameDTO> games;
        public decimal Sum;

        public OrderGames(OrderDTO order, List<OrderlineDTO> orderlines, List<PlatformGameDTO> platformgames, List<GameDTO> games)
        {
            this.order = order;
            this.orderlines = orderlines;
            this.platformgames = platformgames;
            this.games = games;
            getTotalSum();
        }

        public OrderDTO GetOrder()
        {
            return order;
        }

        public List<OrderlineDTO> GetOrderlines()
        {
            return orderlines;
        }

        public List<PlatformGameDTO> GetPlatformGames()
        {
            return platformgames;
        }

        public List<GameDTO> GetGames()
        {
            return games;
        }

        public void getTotalSum()
        {
            decimal sum = 0;

            foreach (var platformgame in platformgames)
            {
                sum = sum + platformgame.Price;
            }
            Sum = sum;
        }

    }
}