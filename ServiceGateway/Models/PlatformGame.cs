using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceGateway.Models
{
    public class PlatformGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Platform Platform { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1.00, 999.00,ErrorMessage = "Price must be between 1.00 and 3999.00")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
