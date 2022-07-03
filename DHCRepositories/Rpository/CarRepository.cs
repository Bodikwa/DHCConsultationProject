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
    public class CarRepository : ICarRepository
    {
        private readonly DHCConsultingDBContext _context;
      
        public CarRepository(DHCConsultingDBContext context)
        {
            _context = context;
        }

        public void DeleteCar(int CarId)
        {
            Car car = _context.Cars.Find(CarId);
            _context.Cars.Remove(car);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int CarId)
        {
            return _context.Cars.Find(CarId);
        }

        public void InsertCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public void SaveCar()
        {
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
        }
    }
}
