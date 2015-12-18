using BusinessLogic.CrewLogic;
using DTOModels.Models;
using MVOGamesUI.Areas.User.Models;
using MVOGamesUI.Areas.User.ViewModels;
using ServiceGateway;
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
            CrewDTO crew = facade.GetCrewGateway().Get(crewId);
            PlatformGameDTO pfg = facade.GetPlatformGameGateway().Get(pfGameId);
            CrewGameSuggestionDTO cgs = new CrewGameSuggestionDTO() { Crew = crew, CrewId = crew.Id, PlatformGame = pfg, PlatformGameId = pfg.Id, Discount = discount };
            return View(cgs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrewBuySpecification([Bind(Include = "CrewId,Crew,PlatformGameId,Discount,ExpirationTime,ExpirationDate")]CrewGameSuggestionDTO cgs)
        {
            
            if (!ModelState.IsValid)
            {
                var platformGame = facade.GetPlatformGameGateway().Get(cgs.PlatformGameId);
                cgs.PlatformGame = platformGame;
                return View(cgs);
            }
       
            //Here is to reply with warning message if not valid!!!!!!!!!!!!
            if (!cp.IsDateValid(cgs.ExpirationDate, cgs.ExpirationTime.TimeOfDay))
            {
                ViewBag.ErrorMessage = "Date and time must be at least 5 minutes from now!";
                var platformGame = facade.GetPlatformGameGateway().Get(cgs.PlatformGameId);
                cgs.PlatformGame = platformGame;
                return View(cgs);
            }
            

            //CrewGameSuggestion cgs = new CrewGameSuggestion() { Crew = crew, CrewId = crew.Id, PlatformGame = pfg, PlatformGameId = pfg.Id, Discount = discount };
            return RedirectToAction("Confirmation", "CrewBuy", new { crewId = cgs.CrewId,
                discount = cgs.Discount, expDate = cgs.ExpirationDate, expTime = cgs.ExpirationTime,
                 platformGameId = cgs.PlatformGameId});
        }
        

            public ActionResult Confirmation(int crewId, int discount, DateTime expDate, DateTime expTime, int platformGameId)
        {
            CrewGameSuggestionDTO cgs = new CrewGameSuggestionDTO() { CrewId = crewId,
                Discount = discount, ExpirationDate = expDate, ExpirationTime = expTime,
                PlatformGameId = platformGameId };

            UserDTO user = Auth.user;
            PlatformGameDTO pfGame = facade.GetPlatformGameGateway().Get(platformGameId);
            CrewDTO crew = facade.GetCrewGateway().Get(crewId);
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
            CrewGameSuggestionDTO cgs = (CrewGameSuggestionDTO)Session["CrewGameSuggestion"];
            cgs.PlatformGame = facade.GetPlatformGameGateway().Get(cgs.PlatformGameId);
            cgs.Crew = facade.GetCrewGateway().Get(cgs.CrewId);
            facade.GetCrewGameSuggestionGateway().Create(cgs);

            CrewGameSuggestionDTO cgsWithId = facade.GetCrewGameSuggestionGateway().GetAll().Last();
            SuggestionUsersDTO su = new SuggestionUsersDTO() { CrewGameSuggestionId = cgsWithId.Id,
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