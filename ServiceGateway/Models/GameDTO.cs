using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway.Models
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }
        public virtual List<PlatformGameDTO> GPlatforms { get; set; }
        public virtual List<GenreDTO> Genres { get; set; }
    }
}
