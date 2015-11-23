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
            Games = new List<Game>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; } 
    }
}
