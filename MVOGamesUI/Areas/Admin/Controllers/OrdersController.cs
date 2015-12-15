using MVOGamesUI.Areas.Admin.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using ServiceGateway.Models;
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
        List<PlatformGame> platforGames = new List<PlatformGame>();
        List<Orderline> orderline = new List<Orderline>();
        List<Game> games = new List<Game>();
        decimal sum = 0;

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = facade.GetOrderGateway().GetAll();
            return View(orders);
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = facade.GetOrderGateway().Get(id);
            List<Orderline> orderlines = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id).ToList();

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
            Order order = facade.GetOrderGateway().Get(id);
            List<Orderline> orderlines = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id).ToList();

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
            Order order = facade.GetOrderGateway().Get(id);
            List<Orderline> orderlines = facade.GetOrderlineGateway().GetAll().Where(o => o.OrderId == order.Id).ToList();

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
            Order order = facade.GetOrderGateway().Get(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            facade.GetOrderlineGateway().Delete(id);

            return RedirectToAction("Edit" + "/" + orderId);
        }

        // GET: Admin/Order/NewGameToOrder/5
        //public ActionResult NewGameToOrder(int? id)
        public ActionResult NewGameToOrder(int orderId, Orderline orderline)
        {
            ViewBag.GameList = new SelectList(facade.GetPlatformGameGateway().GetAll().OrderBy(g => g.Game.Title).Select(g => g.Game.Title), orderline.PlatformGameId);
            return View();
        }

        // POST: Admin/Order/NewGameToOrder/5
        [HttpPost]
        public ActionResult newGameToOrder(Orderline orderline, int? orderId)
        {
            if (orderline == null || orderId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = facade.GetOrderGateway().Get(orderId);
            if (order == null)
            {
                return HttpNotFound();
            }
            orderline.PlatformGame = facade.GetPlatformGameGateway().Get(orderline.PlatformGameId);
            facade.GetOrderlineGateway().Create(orderline);
            ViewBag.GameList = new SelectList(facade.GetPlatformGameGateway().GetAll().OrderBy(g => g.Game.Title).Select(g => g.Game.Title), orderline.PlatformGameId);

            return RedirectToAction("Edit" + "/" + orderId);
        }
    }
}
