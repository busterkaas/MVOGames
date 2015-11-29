using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVOGamesUI.Infrastructure;
using ServiceGateway;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    [SelectedTab("profile")]
    public class ProfileController : Controller
    {
        Facade facade = new Facade();
        // GET: User/Profile
        public ActionResult Index()
        {
            var user = facade.GetUserGateway().Get(Auth.user.Id);
            return View(user);
        }
    }
}