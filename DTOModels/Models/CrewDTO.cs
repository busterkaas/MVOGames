using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class CrewDTO
    {
        public int Id { get; set; }
        //[Required]
        //[MinLength(2)]
        //[DisplayName("Crew name")]
        public string Name { get; set; }
        //[DisplayName("Crew image url")]
        public string CrewImgUrl { get; set; }
        public int CrewLeaderId { get; set; }
        //public UserDTO CrewLeader { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}
