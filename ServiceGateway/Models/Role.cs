﻿using System.Collections.Generic;

namespace ServiceGateway.Models
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual List<User> Users { get; set; }
    }
    
}
