using System.Collections.Generic;

namespace ServiceGateway.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
