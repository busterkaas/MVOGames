using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceGateway.Models
{
    public class Crew
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public string CrewImgUrl { get; set; }
        public int CrewLeaderId { get; set; }
        //public virtual User CrewLeader { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<CrewApplication> Applications { get; set; }  
    }
}
