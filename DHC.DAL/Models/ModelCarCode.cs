using System;
using System.Collections.Generic;

#nullable disable

namespace DHC.DAL.Models
{
    public partial class ModelCarCode
    {
        public ModelCarCode()
        {
            Cars = new HashSet<Car>();
            Users = new HashSet<User>();
        }

        public int ModelCodeId { get; set; }
        public string ModelCode { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
