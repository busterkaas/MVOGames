using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVOGamesUI.ViewModels;
using ServiceGateway;
using DTOModels.Models;

namespace MVOGamesUI.Controllers
{
    public class AuthController : Controller
    {
        Facade facade = new Facade();
        // GET: Auth
        public ActionResult Login()
        {
            return View(new AuthLogin{});
        }
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            UserDTO user;
            List<UserDTO> users = facade.GetUserGateway().GetAll().ToList();
            try
            {
                user = users.First(u => u.Username == form.Username);
            }
            catch
            {user = null;}

            //Metoden under, er en ekstra måde at sikre sig på. 
            //den gør bare at der er ikke er tidsforskel på, hvis en bruger er 
            //eller ikke er rigistreret i databasen

            if (user == null)
            {
                DTOModels.Models.UserDTO.FakeHash();
            }

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

            if(user.Role.RoleName=="admin")
            {
                return RedirectToAction("Index", "Games", new {area = "Admin"});
            }
            else 
            {
                return RedirectToAction("Index", "Profile", new { area = "User" });
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email,PasswordHash")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                user.SetPassword(user.PasswordHash);
                //get user role and set it for the new user
                RoleDTO role = facade.GetRoleGateway().Get(2);
                user.Role = role;
                facade.GetUserGateway().Create(user);
                FormsAuthentication.SetAuthCookie(user.Username, true);
                return RedirectToAction("Index", "Profile", new { area = "User" });
            }
            return View();
        }

    }
}