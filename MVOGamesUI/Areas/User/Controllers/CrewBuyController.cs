using BusinessLogic.CrewLogic;
using MVOGamesUI.Areas.User.Models;
using MVOGamesUI.Areas.User.ViewModels;
using ServiceGateway;
using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    public class CrewBuyController : Controller
    {
        Facade facade = new Facade();
        CrewPermission cp = new CrewPermission();
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
        public ActionResult CrewBuySpecification([Bind(Include = "CrewId,Crew,PlatformGameId,Discount,ExpirationTime,ExpirationDate")]CrewGameSuggestion cgs)
        {
            
            if (!ModelState.IsValid)
            {
                return View(cgs);
            }
       
            //Here is to reply with warning message if not valid!!!!!!!!!!!!
            if (!cp.IsDateValid(cgs.ExpirationDate, cgs.ExpirationTime.TimeOfDay))
            {
                return View(cgs);
            }
            

            //CrewGameSuggestion cgs = new CrewGameSuggestion() { Crew = crew, CrewId = crew.Id, PlatformGame = pfg, PlatformGameId = pfg.Id, Discount = discount };
            return RedirectToAction("Confirmation", "CrewBuy", new { crewId = cgs.CrewId,
                discount = cgs.Discount, expDate = cgs.ExpirationDate, expTime = cgs.ExpirationTime,
                 platformGameId = cgs.PlatformGameId});
        }
        

            public ActionResult Confirmation(int crewId, int discount, DateTime expDate, DateTime expTime, int platformGameId)
        {
            CrewGameSuggestion cgs = new CrewGameSuggestion() { CrewId = crewId,
                Discount = discount, ExpirationDate = expDate, ExpirationTime = expTime,
                PlatformGameId = platformGameId };

            ServiceGateway.Models.User user = Auth.user;
            PlatformGame pfGame = facade.GetPlatformGameGateway().Get(platformGameId);
            Crew crew = facade.GetCrewGateway().Get(crewId);
            CrewBuyConfirmationVM viewModel = new CrewBuyConfirmationVM(user, pfGame, crew);


            Session["CrewGameSuggestion"] = cgs;


            return View(viewModel);
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
            return RedirectToAction("Done", "CrewBuy", new { cardType = fakepayment.CardType, cardNumber = fakepayment.CardNumber, expMonth = fakepayment.ExpMonth, expYear = fakepayment.ExpYear, cvv = fakepayment.Cvv, cardOwner = fakepayment.CardOwner });
        }
        public ActionResult Done()
        {
           CrewGameSuggestion cgs = (CrewGameSuggestion)Session["CrewGameSuggestion"];
            cgs.PlatformGame = facade.GetPlatformGameGateway().Get(cgs.PlatformGameId);
            cgs.Crew = facade.GetCrewGateway().Get(cgs.CrewId);
            facade.GetCrewGameSuggestionGateway().Create(cgs);

            CrewGameSuggestion cgsWithId = facade.GetCrewGameSuggestionGateway().GetAll().Last();
            SuggestionUsers su = new SuggestionUsers() { CrewGameSuggestionId = cgsWithId.Id,
                                                        CrewGameSuggestion = cgsWithId, UserId = 
                                                        Auth.user.Id, User = Auth.user, HasConfirmed = true};
            facade.GetSuggestionUsersGateway().Create(su);

            return View(cgsWithId);
        }

        private decimal getDiscount()
        {
            return 0;
        }
    }
}