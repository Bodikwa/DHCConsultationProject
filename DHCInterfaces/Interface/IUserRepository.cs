using DHC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCInterfaces.Interface
{
   public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int UserId);
        void InsertUser(User user);
        void Update(User user);
        void DeleteUser(int UserId);
        void SaveUser();
    }
}
