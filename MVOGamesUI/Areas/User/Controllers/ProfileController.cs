using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVOGamesUI.Areas.User.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using DTOModels.Models;

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
            var user = Auth.user;
            var crews = facade.GetCrewGateway().GetAll().ToList();
            var userCrews = from c in crews
                where c.Users.Any(u => u.Id == user.Id)
                select c;
            UserCrew uc = new UserCrew(user, userCrews.ToList());  
               
            return View(uc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Username,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email, PasswordHash")] UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                var userLoggedIn = Auth.user;
                var crews = facade.GetCrewGateway().GetAll().ToList();
                var userCrews = from c in crews
                                where c.Users.Any(u => u.Id == userLoggedIn.Id)
                                select c;
                UserCrew uc = new UserCrew(userLoggedIn, userCrews.ToList());
                return View(uc);
            }

            ViewBag.message = " - User has been updated!";
            UserDTO newUser = Auth.user;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.StreetName = user.StreetName;
            newUser.HouseNr = user.HouseNr;
            newUser.ZipCode = user.ZipCode;
            newUser.City = user.City;
            newUser.Email = user.Email;

            newUser.Username = user.Username;

            FormsAuthentication.SetAuthCookie(newUser.Username, true);


            facade.GetUserGateway().Update(newUser);


            var crewss = facade.GetCrewGateway().GetAll().ToList();
            var userCrewss = from c in crewss
                            where c.Users.Any(u => u.Id == newUser.Id)
                            select c;
            UserCrew ucc = new UserCrew(newUser, userCrewss.ToList());

            return View(ucc);
        }
    }
}