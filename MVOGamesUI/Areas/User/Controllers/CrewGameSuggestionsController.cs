using BusinessLogic.OrderLogic;
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
                facade.GetSuggestionUsersGateway().Create(new SuggestionUsersDTO() { CrewGameSuggestionId = crewGameSugId, CrewGameSuggestion = crewGameSuggestion, HasConfirmed = false,UserId = Auth.user.Id, User = Auth.user });
                return RedirectToAction("Details", new { crewGameSuggestionId = crewGameSugId });
            }
            return RedirectToAction("Confirmation", new { crewGameSuggestionId = crewGameSugId });
        }
        public ActionResult Confirmation(int crewGameSuggestionId)
        {
            var cgs = facade.GetCrewGameSuggestionGateway().Get(crewGameSuggestionId);


            Session["cgs"] = cgs;


            UserDTO user = Auth.user;
            PlatformGameDTO pfGame = cgs.PlatformGame;
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
            CrewGameSuggestionDTO cgs = (CrewGameSuggestionDTO)Session["cgs"];
            facade.GetSuggestionUsersGateway().Create(new SuggestionUsersDTO() { CrewGameSuggestion = cgs, CrewGameSuggestionId = cgs.Id, User = Auth.user, UserId = Auth.user.Id, HasConfirmed=true });
            return RedirectToAction("Details", "CrewGameSuggestions", new { crewGameSuggestionId = cgs.Id });
        }
        
        public ActionResult CreateOrdersForCrew(int crewGameSuggestionId)
        {
            var crewGameSuggestion = facade.GetCrewGameSuggestionGateway().Get(crewGameSuggestionId);
            List<SuggestionUsersDTO> suggestionUsers = facade.GetSuggestionUsersGateway().GetAll().Where(
                                    u => u.CrewGameSuggestionId == crewGameSuggestionId).Where(
                                    u=>u.HasConfirmed==true).ToList();
            foreach(SuggestionUsersDTO user in suggestionUsers)
            {
                    //create order
                    DateTime date = crewGameSuggestion.ExpirationDate;
                    TimeSpan ts =  crewGameSuggestion.ExpirationTime.TimeOfDay;
                    DateTime orderDate = date + ts;
                var order = new OrderDTO() { Date = orderDate, User = user.User, UserId = user.UserId };
                    facade.GetOrderGateway().Create(order);
                var orders = facade.GetOrderGateway().GetAll();
                    //create orderline 
                var myOrder = orders.Where(o => o.UserId == user.UserId).Last();
                var orderline = new OrderlineDTO() { Amount = 1, Discount =
                                                    cd.CalculateDiscountDKK(suggestionUsers.Count(), crewGameSuggestion.PlatformGame.Price),
                                                    OrderId = myOrder.Id, PlatformGameId = crewGameSuggestion.PlatformGameId };
                    facade.GetOrderlineGateway().Create(orderline);
               
            }
            //Delete crew-game-suggestion
            facade.GetCrewGameSuggestionGateway().Delete(crewGameSuggestion.Id);
            return RedirectToAction("MyCrew", "Crews", new { id = crewGameSuggestion.CrewId });
        }
    }
}