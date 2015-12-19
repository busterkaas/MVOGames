using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class OrderIndexVM
    {
        public OrderIndexVM(UserDTO user, List<OrderDTO> orders, OrderDTO selectedOrder)
        {
            User = user;
            Orders = orders;
            SelectedOrder = selectedOrder;
        }
        public UserDTO User { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public OrderDTO SelectedOrder { get; set; }
    }
}