using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class MyCrewViewModel
    {
        public MyCrewViewModel(ServiceGateway.Models.User user, Crew crew, List<CrewGameSuggestion> crewSuggestions, List<CrewApplication> applications)
        {
            User = user;
            Crew = crew;
            CrewSuggestions = crewSuggestions;
            Applications = applications;
        }
        public Crew Crew { get; set; }
        public List<CrewGameSuggestion> CrewSuggestions { get; set; }
        public List<CrewApplication> Applications { get; set; }
        public ServiceGateway.Models.User User { get; set; }
    }
}