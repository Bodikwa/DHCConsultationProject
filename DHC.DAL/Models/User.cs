using System;
using System.Collections.Generic;

#nullable disable

namespace DHC.DAL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserLocation { get; set; }
        public int CarId { get; set; }
        public int ManagerId { get; set; }
        public int ModelCodeId { get; set; }
        public int ModelNameId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ModelCarCode ModelCode { get; set; }
        public virtual ModelCarName ModelName { get; set; }
    }
}
