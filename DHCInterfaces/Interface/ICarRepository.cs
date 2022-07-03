using DHC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCInterfaces.Interface
{
   public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int CarId);
        void InsertCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int CarId);
        void SaveCar();
    }
}
