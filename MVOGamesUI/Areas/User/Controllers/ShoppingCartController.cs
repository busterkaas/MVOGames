using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVOGamesUI.Areas.User.Models.ShoppingCartModels;
using ServiceGateway;

namespace MVOGamesUI.Areas.User.Controllers
{
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