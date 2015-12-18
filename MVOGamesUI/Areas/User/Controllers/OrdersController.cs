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
        public ActionResult MyOrders()
        {
            UserDTO user = Auth.user;
            var myOrders = facade.GetOrderGateway().GetAll().Where(o => o.UserId == user.Id).ToList();

            //foreach(var order in myOrders)
            //{
            //    order.Orderlines = new List<Orderline>();
            //    var orderlinesForUser = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id);
            //}
            OrderIndexVM viewModel = new OrderIndexVM(user, myOrders);
            return View(viewModel);
        }
    }
}