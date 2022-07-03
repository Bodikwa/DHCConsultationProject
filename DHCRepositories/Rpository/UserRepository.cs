using DHC.DAL.Models;
using DHCInterfaces.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCRepositories.Rpository
{
    public class UserRepository : IUserRepository
    {

        private readonly DHCConsultingDBContext _context;

        public UserRepository(DHCConsultingDBContext context)
        {
            _context = context;
        }


        public void DeleteUser(int UserId)
        {
            User user = _context.Users.Find(UserId);
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int UserId)
        {
            return _context.Users.Find(UserId);
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void SaveUser()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
