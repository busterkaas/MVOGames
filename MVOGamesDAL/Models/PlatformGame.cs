using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Models
{
    public class PlatformGame
    {
        [Key]
        [Column(Order = 1)]
        public int GameId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PlatformId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Platform Platform { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1.00, 999.00,ErrorMessage = "Price must be between 1.00 and 3999.00")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
