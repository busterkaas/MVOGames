using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Models
{
    public class SuggestionUsers
    {
        public int Id { get; set; }
        public int CrewGameSuggestionId { get; set; }
        public virtual CrewGameSuggestion CrewGameSuggestion { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public bool HasConfirmed { get; set; }

    }
}
