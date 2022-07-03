using DHC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCInterfaces.Interface
{
    public interface IModelCarCodeRepository
    {
        IEnumerable<ModelCarCode> GetAllModelCarCodes();
        ModelCarCode GetModelCarCodeById(int ModelCarCodeId);
        void InsertModelCarCode(ModelCarCode modelCarCode);
        void UpdateModelCarCode(ModelCarCode modelCarCode);
        void Delete(int ModelCarCodeId);
        void Save();
    }
}
