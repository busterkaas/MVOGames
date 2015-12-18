using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class GameDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }
        public List<PlatformGameDTO> GPlatforms { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}
