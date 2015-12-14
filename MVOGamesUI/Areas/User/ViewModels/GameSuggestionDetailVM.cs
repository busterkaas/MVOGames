using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GameSuggestionDetailVM
    {
        public GameSuggestionDetailVM(CrewGameSuggestion cgs, List<SuggestionUsers> sUsers)
        {
            CrewGameSuggestion = cgs;
            SuggestionUsers = sUsers;
        }
        public CrewGameSuggestion CrewGameSuggestion { get; set; }
        public List<SuggestionUsers> SuggestionUsers { get; set; }
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