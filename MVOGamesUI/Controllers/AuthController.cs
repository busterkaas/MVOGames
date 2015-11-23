using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVOGamesDAL;
using MVOGamesUI.ViewModels;

namespace MVOGamesUI.Controllers
{
    public class AuthController : Controller
    {
        DALFacade facade = new DALFacade();
        // GET: Auth
        public ActionResult Login()
        {
            return View(new AuthLogin{});
        }
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            var user = facade.GetUserRepository().FindByUsername(form.Username);
            
            //Den udmarkerede metode under, er en ekstra måde at sikre sig på. 
            //den gør bare at der er ikke er tidsforskel på, hvis en bruger er 
            //eller ikke er rigistreret i databasen :

            //if (user == null)
            //{
            //    MVOGamesDAL.Models.User.FakeHash();
            //}

            if (user == null|| !user.CheckPassword(form.Password))
            {
                ModelState.AddModelError("Username", "Username or password is incorrect");
            }

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            FormsAuthentication.SetAuthCookie(user.Username, true);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            if (user.Role.RoleName == "admin")
            {
                return RedirectToAction("Index", "Games", new {area = "Admin"});
            }
            else
            {
                return RedirectToAction("Index", "Games", new { area = "User" });
            }
            //return RedirectToRoute("home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
    }
}