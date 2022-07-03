using System;
using System.Collections.Generic;

#nullable disable

namespace DHC.DAL.Models
{
    public partial class ModelCarName
    {
        public ModelCarName()
        {
            Cars = new HashSet<Car>();
            Users = new HashSet<User>();
        }

        public int ModelNameId { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
