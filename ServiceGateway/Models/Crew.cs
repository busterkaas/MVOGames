using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceGateway.Models
{
    public class Crew
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [DisplayName("Crew name")]
        public string Name { get; set; }
        [DisplayName("Crew Image (Url)")]
        public string CrewImgUrl { get; set; }
        public int CrewLeaderId { get; set; }
        //public virtual User CrewLeader { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<CrewApplication> Applications { get; set; }  
    }
}
