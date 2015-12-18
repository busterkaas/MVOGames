using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class CrewGameSuggestionDTO
    {
        public int Id { get; set; }
        [Required]
        public int CrewId { get; set; }
        public CrewDTO Crew { get; set; }
        [Required]
        public int PlatformGameId { get; set; }
        public PlatformGameDTO PlatformGame { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Expiration time")]
        public DateTime ExpirationTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Expiration date")]
        public DateTime ExpirationDate { get; set; }
    }
}
