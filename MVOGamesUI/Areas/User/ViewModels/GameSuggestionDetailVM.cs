
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GameSuggestionDetailVM
    {
        public GameSuggestionDetailVM(CrewGameSuggestionDTO cgs, List<SuggestionUsersDTO> sUsers)
        {
            CrewGameSuggestion = cgs;
            SuggestionUsers = sUsers;
        }
        public CrewGameSuggestionDTO CrewGameSuggestion { get; set; }
        public List<SuggestionUsersDTO> SuggestionUsers { get; set; }
        public bool isInList()
        {
            foreach(var suggestionsUser in SuggestionUsers)
            {
                if (suggestionsUser.UserId == Auth.user.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}