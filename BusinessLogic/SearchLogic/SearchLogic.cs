using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SearchLogic
{
    public class SearchLogic
    {
        public IEnumerable<User> UserSearch(IEnumerable<User> users, string input)
        {
            List<User> matchedUser = new List<User>();
            foreach (User user in users)
            {
                if (user.Email.ToLower().Contains(input.ToLower()) || user.Username.ToLower().Contains(input.ToLower())
                    || user.FirstName.ToLower().Contains(input.ToLower()) || user.LastName.ToLower().Contains(input.ToLower())
                    || user.StreetName.ToLower().Contains(input.ToLower()) || user.HouseNr.ToLower().Contains(input.ToLower())
                    || user.City.ToLower().Contains(input.ToLower()))
                {
                    matchedUser.Add(user);
                }
            }
            return matchedUser;
        }

        public IEnumerable<Game> GameSearch(IEnumerable<Game> games, string input)
        {
            List<Game> matchedGame = new List<Game>();
            foreach (Game game in games)
            {
                if (game.Title.ToLower().Contains(input.ToLower()))
                {
                    matchedGame.Add(game);
                }
            }
            return matchedGame;
        }
    }
}
