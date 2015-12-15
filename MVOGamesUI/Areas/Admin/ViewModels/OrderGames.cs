﻿using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class OrderGames
    {
        private Order order;
        private List<Orderline> orderlines;
        private List<PlatformGame> platformgames;
        private List<Game> games;
        public decimal Sum;

        public OrderGames(Order order, List<Orderline> orderlines, List<PlatformGame> platformgames, List<Game> games)
        {
            this.order = order;
            this.orderlines = orderlines;
            this.platformgames = platformgames;
            this.games = games;
            getTotalSum();
        }

        public Order GetOrder()
        {
            return order;
        }

        public List<Orderline> GetOrderlines()
        {
            return orderlines;
        }

        public List<PlatformGame> GetPlatformGames()
        {
            return platformgames;
        }

        public List<Game> GetGames()
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