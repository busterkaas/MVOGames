
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class MyCrewViewModel
    {
        public MyCrewViewModel(UserDTO user, CrewDTO crew, List<CrewGameSuggestionDTO> crewSuggestions, List<CrewApplicationDTO> applications)
        {
            User = user;
            Crew = crew;
            CrewSuggestions = crewSuggestions;
            Applications = applications;
        }
        public CrewDTO Crew { get; set; }
        public List<CrewGameSuggestionDTO> CrewSuggestions { get; set; }
        public List<CrewApplicationDTO> Applications { get; set; }
        public UserDTO User { get; set; }
    }
}