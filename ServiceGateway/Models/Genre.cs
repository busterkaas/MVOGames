using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceGateway.Models
{
    public class Genre
    {
        public Genre()
        {
            Games = new List<Game>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}
