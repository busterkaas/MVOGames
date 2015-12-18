using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public List<OrderlineDTO> Orderlines { get; set; }
    }
}
