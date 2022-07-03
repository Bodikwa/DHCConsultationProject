using DHC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCInterfaces.Interface
{
    public interface IModelCarNameRepository
    {
        IEnumerable<ModelCarName> GetAllModelCarNames();
        ModelCarName GetModelCarNameById(int ModelCarNameId);
        void InsertModelCarName(ModelCarName modelCarName);
        void UpdateModelCarName(ModelCarName modelCarName);
        void DeleteModelCarName(int ModelCarNameId);
        void SaveModelCarName();
    }
}
