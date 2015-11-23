using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVOGamesUI.Controllers;

namespace MVOGamesUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //---------------------------------------------------------------
            //-------------THIS IS FOR NON-AREA-CONTROLLERS------------------

            var namespaces = new[] { typeof (GamesController).Namespace};
            //routes for Auth controller
            routes.MapRoute("Login", "login", new {Controller = "Auth", action = "Login"}, namespaces);
            routes.MapRoute("Logout", "logout", new { Controller = "Auth", action = "Logout" }, namespaces);

            //routes for game controller without area
            routes.MapRoute("Games", "games", new { Controller = "Games", action = "Index" }, namespaces);

            //routes for Home controller
            routes.MapRoute("Contact", "contact", new {Controller = "Home", action = "Contact"}, namespaces);
            routes.MapRoute("About", "about", new { Controller = "Home", action = "About" }, namespaces);
            routes.MapRoute("Home", "", new { Controller = "Home", action = "Index" }, namespaces);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
