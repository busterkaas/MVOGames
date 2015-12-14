using BusinessLogic.OrderLogic;
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
            return RedirectToAction("Details", new { crewGameSuggestionId = crewGameSugId });
        }
    }
}