using Domain.Core.App.Cars.Data;
using Domain.Core.App.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Cars.AppServices
{
    public interface ICarAppService
    {
        public List<Car> GetAllCars();
        public Car GetCarsById(int id);
        public bool AddCar(Car car);
        public bool Delete(int id);
        public bool Update(Car car);
    }
}
