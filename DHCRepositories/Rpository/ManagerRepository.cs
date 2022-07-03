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
    public class ManagerRepository : IManagerRepository
    {

        private readonly DHCConsultingDBContext _context;

        public ManagerRepository(DHCConsultingDBContext context)
        {
            _context = context;
        }

        public void DeleteManager(int ManagerId)
        {
            Manager manager = _context.Managers.Find(ManagerId);
            _context.Managers.Remove(manager);
        }

        public IEnumerable<Manager> GetAllManagers()
        {
            return _context.Managers.ToList();
        }

        public Manager GetManagerById(int ManagerId)
        {
            return _context.Managers.Find(ManagerId);
        }

        public void InsertManager(Manager manager)
        {
            _context.Managers.Add(manager);
        }

        public void SaveManager()
        {
            _context.SaveChanges();
        }

        public void UpdateManager(Manager manager)
        {
            _context.Entry(manager).State = EntityState.Modified;
        }
    }
}
