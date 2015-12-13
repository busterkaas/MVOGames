using ServiceGateway;
using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.User.Controllers
{
    public class CrewBuyController : Controller
    {
        Facade facade = new Facade();
        // GET: User/CrewBuy
        public ActionResult CrewBuySpecification(int pfGameId, int crewId)
        {
            decimal discount = getDiscount();
            Crew crew = facade.GetCrewGateway().Get(crewId);
            PlatformGame pfg = facade.GetPlatformGameGateway().Get(pfGameId);
            CrewGameSuggestion cgs = new CrewGameSuggestion() { Crew = crew, CrewId = crew.Id, PlatformGame = pfg, PlatformGameId = pfg.Id, Discount = discount };
            return View(cgs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrewBuySpecification([Bind(Include = "CrewId,Crew,PlatformGameId,PlatformGame,Discount,ExpirationTime,ExpirationDate")]CrewGameSuggestion cgs)
        {
            if (!ModelState.IsValid)
            {
                return View(cgs);
            }

            //CrewGameSuggestion cgs = new CrewGameSuggestion() { Crew = crew, CrewId = crew.Id, PlatformGame = pfg, PlatformGameId = pfg.Id, Discount = discount };
            return RedirectToAction("Confirmation", "CrewBuy", new { crew = cgs.Crew, crewId = cgs.CrewId, discount = cgs.Discount, expDate = cgs.ExpirationDate, expTime = cgs.ExpirationTime, platformGame = cgs.PlatformGame, platformGameId = cgs.PlatformGameId});
        }
        

            public ActionResult Confirmation(Crew crew, int crewId, int discount, DateTime expDate, DateTime expTime, PlatformGame platformGame, int platformGameId)
        {
            CrewGameSuggestion cgs = new CrewGameSuggestion() { Crew = crew, CrewId = crewId, Discount = discount, ExpirationDate = expDate, ExpirationTime = expTime, PlatformGame = platformGame, PlatformGameId = platformGameId };
            return View(cgs);
        }

        private decimal getDiscount()
        {
            return 0;
        }
    }
}