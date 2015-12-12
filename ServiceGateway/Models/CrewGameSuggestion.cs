using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Models
{
    public class CrewGameSuggestion
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public virtual Crew Crew { get; set; }
        public int PlatformGameId { get; set; }
        public virtual PlatformGame PlatformGame { get; set; }
        public decimal Discount { get; set; }
        [DataType(DataType.Time)]
        public DateTime ExpirationTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

    }
}
