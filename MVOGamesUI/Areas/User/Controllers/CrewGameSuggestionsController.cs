using BusinessLogic.OrderLogic;
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
    public class CrewGameSuggestionsController : Controller
    {
        Facade facade = new Facade();
        CrewDiscount cd = new CrewDiscount();
        // GET: User/CrewGameSuggestions
        public ActionResult Details(int crewGameSuggestionId)
        {
            var crewGameSuggestion = facade.GetCrewGameSuggestionGateway().Get(crewGameSuggestionId);
            var users = facade.GetSuggestionUsersGateway().GetAll().Where(s => s.CrewGameSuggestionId == crewGameSuggestion.Id);
            int userCountForBuy = users.Where(u => u.HasConfirmed == true).Count();
            decimal price = cd.CalculatePrice(userCountForBuy, crewGameSuggestion.PlatformGame.Price);
            crewGameSuggestion.PlatformGame.Price = price;

            GameSuggestionDetailVM gsdViewModel = new GameSuggestionDetailVM(crewGameSuggestion, users.ToList());
            return View(gsdViewModel);
        }

        public ActionResult JoinCrewGame(bool join, int crewGameSugId)
        {
            if (!join)
            {
                var crewGameSuggestion = facade.GetCrewGameSuggestionGateway().Get(crewGameSugId);
                facade.GetSuggestionUsersGateway().Create(new SuggestionUsers() { CrewGameSuggestionId = crewGameSugId, CrewGameSuggestion = crewGameSuggestion, HasConfirmed = false,UserId = Auth.user.Id, User = Auth.user });
                return RedirectToAction("Details", new { crewGameSuggestionId = crewGameSugId });
            }
            return RedirectToAction("Confirmation", new { crewGameSuggestionId = crewGameSugId });
        }
        public ActionResult Confirmation(int crewGameSuggestionId)
        {
            var cgs = facade.GetCrewGameSuggestionGateway().Get(crewGameSuggestionId);


            Session["cgs"] = cgs;


            ServiceGateway.Models.User user = Auth.user;
            PlatformGame pfGame = cgs.PlatformGame;
            CrewBuyConfirmationVM cbcViewModel = new CrewBuyConfirmationVM(user, pfGame, cgs.Crew);
            return View(cbcViewModel);
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
            return RedirectToAction("Done", "CrewGameSuggestions", new { cardType = fakepayment.CardType, cardNumber = fakepayment.CardNumber, expMonth = fakepayment.ExpMonth, expYear = fakepayment.ExpYear, cvv = fakepayment.Cvv, cardOwner = fakepayment.CardOwner });
        }
        public ActionResult Done()
        {
            CrewGameSuggestion cgs = (CrewGameSuggestion)Session["cgs"];
            facade.GetSuggestionUsersGateway().Create(new SuggestionUsers() { CrewGameSuggestion = cgs, CrewGameSuggestionId = cgs.Id, User = Auth.user, UserId = Auth.user.Id, HasConfirmed=true });
            return RedirectToAction("Details", "CrewGameSuggestions", new { crewGameSuggestionId = cgs.Id });
        }

    }
}