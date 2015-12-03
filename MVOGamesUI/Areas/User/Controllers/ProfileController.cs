using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVOGamesUI.Areas.User.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using ServiceGateway.Models;

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
            var crews = facade.GetCrewGateway().GetAll().ToList();
            var userCrews = from c in crews
                where c.Users.Any(u => u.Id == user.Id)
                select c;
            UserCrew uc = new UserCrew(user, userCrews.ToList());  
               
            return View(uc);
        }
    }
}