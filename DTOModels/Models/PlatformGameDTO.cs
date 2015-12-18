using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class PlatformGameDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public GameDTO Game { get; set; }
        public int PlatformId { get; set; }
        public PlatformDTO Platform { get; set; }
        [Required]
        [Range(1.00, 2000, ErrorMessage = "Price must be between 1.00 and 2001.00")]
        public decimal Price { get; set; }

        public string GamePlatformName
        {
            get {return Game.Title + "  -  " + Platform.Name;}
        }
    }
}
