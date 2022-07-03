using DHC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCInterfaces.Interface
{
   public interface IManagerRepository
    {
        IEnumerable<Manager> GetAllManagers();
        Manager GetManagerById(int ManagerId);
        void InsertManager(Manager manager);
        void UpdateManager(Manager manager);
        void DeleteManager(int ManagerId);
        void SaveManager();
    }
}
