using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
