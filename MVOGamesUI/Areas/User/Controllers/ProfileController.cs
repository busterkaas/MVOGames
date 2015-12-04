using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            ViewBag.message = "";
            var user = facade.GetUserGateway().Get(Auth.user.Id);
            var crews = facade.GetCrewGateway().GetAll().ToList();
            var userCrews = from c in crews
                where c.Users.Any(u => u.Id == user.Id)
                select c;
            UserCrew uc = new UserCrew(user, userCrews.ToList());  
               
            return View(uc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Username,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] ServiceGateway.Models.User user)
        {
            ViewBag.message = " - User has been updated!";
            ServiceGateway.Models.User newUser = Auth.user;
            newUser.Username = user.Username;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.StreetName = user.StreetName;
            newUser.HouseNr = user.HouseNr;
            newUser.ZipCode = user.ZipCode;
            newUser.City = user.City;
            newUser.Email = user.Email;
            FormsAuthentication.SetAuthCookie(newUser.Username, true);
            
            facade.GetUserGateway().Update(newUser);
            return RedirectToAction("Index");
        }
    }
}