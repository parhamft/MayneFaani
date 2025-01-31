using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.Cars.Data;
using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Cars.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.App.Cars
{
    public class CarAppService : ICarAppService
    {
        private readonly ICarService _carService;
        public CarAppService(ICarService carService)
        {
            _carService = carService;
        }
        
        public List<Car> GetAllCars()
        {
            return _carService.GetAllCars();
        }
        public Car GetCarsById(int id)
        {
            return _carService.GetCarsById(id);
        }
        public bool AddCar(Car car)
        {
            return _carService.AddCar(car);
        }
        public bool Delete(int id)
        {
            return _carService.Delete(id);
        }
        public bool Update(Car car)
        {
            return _carService.Update(car);
        }
    }
}
