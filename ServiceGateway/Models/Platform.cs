using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceGateway.Models
{
    public class Platform
    {
        public Platform()
        {
            PGames = new List<PlatformGame>();
        }
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public virtual List<PlatformGame> PGames { get; set; } 
    }
}
