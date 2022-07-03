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
    public class ModelCarCodeRepository : IModelCarCodeRepository
    {

        private readonly DHCConsultingDBContext _context;

        public ModelCarCodeRepository(DHCConsultingDBContext context)
        {
            _context = context;
        }

        public void Delete(int ModelCarCodeId)
        {
            ModelCarCode modelCarCode = _context.ModelCarCodes.Find(ModelCarCodeId);
            _context.ModelCarCodes.Remove(modelCarCode);
        }

        public IEnumerable<ModelCarCode> GetAllModelCarCodes()
        {
            return _context.ModelCarCodes.ToList();
        }

        public ModelCarCode GetModelCarCodeById(int ModelCarCodeId)
        {
            return _context.ModelCarCodes.Find(ModelCarCodeId);
        }

        public void InsertModelCarCode(ModelCarCode modelCarCode)
        {
            _context.ModelCarCodes.Add(modelCarCode);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateModelCarCode(ModelCarCode modelCarCode)
        {
            _context.Entry(modelCarCode).State = EntityState.Modified;
        }
    }
}
