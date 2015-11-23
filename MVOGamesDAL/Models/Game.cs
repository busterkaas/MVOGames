using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Models
{
    public class Game
    {
        public Game()
        {
            Genres = new List<Genre>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "A Title is required!")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1.00, 999.00,
            ErrorMessage = "Price must be between 1.00 and 3999.00")]
        public decimal Price { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }
        public virtual List<Genre> Genres { get; set; }
        
    }
}
