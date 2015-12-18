using DTOModels.Models;
using MVOGamesUI.Areas.Admin.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("orders")]
    public class OrdersController : Controller
    {
        private Facade facade = new Facade();
        List<PlatformGameDTO> platforGames = new List<PlatformGameDTO>();
        List<OrderlineDTO> orderline = new List<OrderlineDTO>();
        List<GameDTO> games = new List<GameDTO>();
       

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = facade.GetOrderGateway().GetAll();
            return View(orders);
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            List<PlatformGameDTO> platforGames = new List<PlatformGameDTO>();
            List<GameDTO> games = new List<GameDTO>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDTO order = facade.GetOrderGateway().Get(id);
            List<OrderlineDTO> orderlines = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id).ToList();

            foreach (var o in orderlines)
            {
                platforGames.Add(facade.GetPlatformGameGateway().Get(o.PlatformGameId));
            }
            foreach (var p in platforGames)
            {
                games.Add(facade.GetGameGateway().Get(p.GameId));
            }
            OrderGames og = new OrderGames(order, orderlines, platforGames, games);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(og);
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDTO order = facade.GetOrderGateway().Get(id);
            List<OrderlineDTO> orderlines = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id).ToList();

            foreach (var o in orderlines)
            {
                platforGames.Add(facade.GetPlatformGameGateway().Get(o.PlatformGameId));
            }
            foreach (var p in platforGames)
            {
                games.Add(facade.GetGameGateway().Get(p.GameId));
            }
            OrderGames og = new OrderGames(order, orderlines, platforGames, games);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(og);
        }

        // POST: Admin/Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDTO order = facade.GetOrderGateway().Get(id);
            List<OrderlineDTO> orderlines = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id).ToList();

            foreach (var o in orderlines)
            {
                platforGames.Add(facade.GetPlatformGameGateway().Get(o.PlatformGameId));
            }
            foreach (var p in platforGames)
            {
                games.Add(facade.GetGameGateway().Get(p.GameId));
            }
            OrderGames og = new OrderGames(order, orderlines, platforGames, games);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(og);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            facade.GetOrderGateway().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/Order/DeleteGameFromOrder/5
        public ActionResult DeleteGameFromOrder(int? id, int? orderId)
        {
            if (id == null || orderId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDTO order = facade.GetOrderGateway().Get(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            facade.GetOrderlineGateway().Delete(id);

            return RedirectToAction("Edit" + "/" + orderId);
        }

        // GET: Admin/Order/NewGameToOrder/5
        //public ActionResult NewGameToOrder(int? id)
        public ActionResult NewGameToOrder(int orderId, OrderlineDTO orderline)
        {
            ViewBag.GameList = new SelectList(facade.GetPlatformGameGateway().GetAll().OrderBy(g => g.Game.Title).Select(g => g.Game.Title), orderline.PlatformGameId);
            return View();
        }

        // POST: Admin/Order/NewGameToOrder/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newGameToOrder([Bind(Include = "Id,Amount,Discount,orderId,PlatformGameId")]OrderlineDTO orderline)
        {
            if (orderline == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            facade.GetOrderlineGateway().Create(orderline);
            ViewBag.GameList = new SelectList(facade.GetPlatformGameGateway().GetAll().OrderBy(g => g.Game.Title).Select(g => g.Game.Title), orderline.PlatformGameId);

            return RedirectToAction("Edit" + "/" + orderline.OrderId);
        }
    }
}
