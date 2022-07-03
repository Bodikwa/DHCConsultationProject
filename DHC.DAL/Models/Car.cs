using System;
using System.Collections.Generic;

#nullable disable

namespace DHC.DAL.Models
{
    public partial class Car
    {
        public Car()
        {
            Users = new HashSet<User>();
        }

        public int CarId { get; set; }
        public string CarName { get; set; }
        public int ModelCodeId { get; set; }
        public int ModelNameId { get; set; }

        public virtual ModelCarCode ModelCode { get; set; }
        public virtual ModelCarName ModelName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
