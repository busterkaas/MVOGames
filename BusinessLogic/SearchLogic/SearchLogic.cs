using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SearchLogic
{
    public class SearchLogic
    {
        public IEnumerable<UserDTO> UserSearch(IEnumerable<UserDTO> users, string input)
        {
            List<UserDTO> matchedUser = new List<UserDTO>();
            foreach (UserDTO user in users)
            {
                if (user.Email.ToLower().Contains(input.ToLower()) || user.Username.ToLower().Contains(input.ToLower())
                    || user.FirstName.ToLower().Contains(input.ToLower()) || user.LastName.ToLower().Contains(input.ToLower()))
                {
                    matchedUser.Add(user);
                }
            }
            return matchedUser;
        }


        public IEnumerable<GameDTO> GameSearch(IEnumerable<GameDTO> games, string input)
        {
            List<GameDTO> matchedGame = new List<GameDTO>();
            foreach (GameDTO game in games)
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
