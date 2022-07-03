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
    public class ModelCarNameRepository : IModelCarNameRepository
    {
        private readonly DHCConsultingDBContext _context;

        public ModelCarNameRepository(DHCConsultingDBContext context)
        {
            _context = context;
        }

        public void DeleteModelCarName(int ModelCarNameId)
        {
            ModelCarName modelCarName = _context.ModelCarNames.Find(ModelCarNameId);
            _context.ModelCarNames.Remove(modelCarName);
        }

        public IEnumerable<ModelCarName> GetAllModelCarNames()
        {
            return _context.ModelCarNames.ToList();
        }

        public ModelCarName GetModelCarNameById(int ModelCarNameId)
        {
            return _context.ModelCarNames.Find(ModelCarNameId);
        }

        public void InsertModelCarName(ModelCarName modelCarName)
        {
            _context.ModelCarNames.Add(modelCarName);
        }

        public void SaveModelCarName()
        {
            _context.SaveChanges();
        }

        public void UpdateModelCarName(ModelCarName modelCarName)
        {
            _context.Entry(modelCarName).State = EntityState.Modified;
        }
    }
}
