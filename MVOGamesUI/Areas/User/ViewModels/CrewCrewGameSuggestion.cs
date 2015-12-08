using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class CrewCrewGameSuggestion
    {
        public CrewCrewGameSuggestion(Crew crew, List<CrewGameSuggestion> crewSuggestions)
        {
            Crew = crew;
            CrewSuggestions = crewSuggestions;
        }
        public Crew Crew { get; set; }
        public List<CrewGameSuggestion> CrewSuggestions { get; set; }
    }
}