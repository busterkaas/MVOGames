using DTOModels.Models;
using MVOGamesUI.Areas.User.ViewModels;
using ServiceGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    public class OrdersController : Controller
    {
        Facade facade = new Facade();
        // GET: User/Orders
        public ActionResult MyOrders(int? orderId)
        {
            UserDTO user = Auth.user;
            var myOrders = facade.GetOrderGateway().GetAll().Where(o => o.UserId == user.Id).ToList();
            OrderDTO selectedOrder = null;

            foreach (var order in myOrders)
            {
                if (orderId != null)
                {
                        if(order.Id == orderId)
                    {
                        selectedOrder = order;
                    }
                }
                order.Orderlines = new List<OrderlineDTO>();
                var orderlinesForUser = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id);
                foreach(var orderline in orderlinesForUser)
                {
                    order.Orderlines.Add(orderline);
                }
            }
            
            OrderIndexVM viewModel = new OrderIndexVM(user, myOrders, selectedOrder);
            return View(viewModel);
        }
        [ChildActionOnly]
        public ActionResult GetPlatformGame(int platformGameId)
        {
            var platformGame = facade.GetPlatformGameGateway().Get(platformGameId);

            return Content(platformGame.Game.Title +" - " + platformGame.Platform.Name);
        }
    }
}