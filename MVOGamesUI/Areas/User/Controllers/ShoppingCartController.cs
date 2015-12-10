using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVOGamesUI.Areas.User.Models.ShoppingCartModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using MVOGamesUI.Areas.User.ViewModels;
using MVOGamesUI.Areas.User.Models;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    [SelectedTab("shoppingcart")]
    public class ShoppingCartController : Controller
    {
        Facade facade;
        ShoppingCartModel cartModel;

        public ShoppingCartController()
        {
            facade = new Facade();
            cartModel = new ShoppingCartModel(facade.GetPlatformGameGateway().GetAll().ToList());
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["cart"] == null)
                Session["cart"] = new List<ShoppingCartItem>();

            cartModel.Items = (List<ShoppingCartItem>)Session["cart"];
        }
        // GET: User/ShoppingCart
        public ActionResult Index()
        {
            return View(cartModel);
        }

        public ActionResult Confirmation()
        {
            if (cartModel == null ||cartModel.Items.Count<1)
            {
                return RedirectToAction("Index");
            }
            ServiceGateway.Models.User user = Auth.user;
            UserCart uc = new UserCart(user, cartModel);
            return View(uc);
        }

        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment([Bind(Include = "CardType, CardNumber, ExpMonth, ExpYear, Cvv, CardOwner")] FakePayment fakepayment)
        {
            if (!ModelState.IsValid)
            {
                return View(fakepayment);
            }
            return RedirectToAction("Checkout", "ShoppingCart", new { cardType = fakepayment.CardType, cardNumber = fakepayment.CardNumber, expMonth = fakepayment.ExpMonth, expYear = fakepayment.ExpYear, cvv = fakepayment.Cvv, cardOwner = fakepayment.CardOwner });
        }

        public ActionResult Checkout(string cardType, int cardNumber, int expMonth, int expYear, int cvv, string cardOwner)
        {
            FakePayment payment = new FakePayment(cardType, cardNumber, expMonth, expYear, cvv, cardOwner);
            ServiceGateway.Models.User user = Auth.user;
            UserCartPayment ucp = new UserCartPayment(user, cartModel, payment);
            try {
                facade.GetOrderGateway().Create(
                    new ServiceGateway.Models.Order() {
                        Date = DateTime.Now, UserId = user.Id });

                var order = facade.GetOrderGateway().GetAll().ToList().Last();
                foreach (var item in cartModel.Items)
                {
                    facade.GetOrderlineGateway().Create(
                        new ServiceGateway.Models.Orderline() {
                            OrderId = order.Id, PlatformGameId = 
                            item.PlatformGameId, Amount = item.Quantity,
                            Discount = 0});
                }
            return View(ucp);
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: /ShoppingCart/Add
        public ActionResult Add(int id)
        {
            cartModel.Add(id);
            return RedirectToAction("Index", "Games", new {Area = "User"});
        }

        // The Initialize() method is invoked just after the constructor. It is
        // used to initialize data that is not available when the constructor is
        // executed.


        // Child action: returns the number of items in the shopping cart
        [ChildActionOnly]
        public ActionResult NoOfItems()
        {
            return Content("[" + cartModel.NoOfItems + "]");
        }
    }
}