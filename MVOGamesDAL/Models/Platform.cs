using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Models
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
