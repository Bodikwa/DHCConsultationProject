using System;
using System.Collections.Generic;

#nullable disable

namespace DHC.DAL.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Users = new HashSet<User>();
        }

        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerContact { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
