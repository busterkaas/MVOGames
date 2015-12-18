using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class CrewApplicationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int CrewId { get; set; }
        public CrewDTO Crew { get; set; }
    }
}
