using Domain.Core.App.Cars.Data;
using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Cars.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.App.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        public CarService(ICarRepository repository)
        {
            carRepository = repository;
        }
        public List<Car> GetAllCars()
        {
            return carRepository.GetAll();
        }
        public Car GetCarsById(int id)
        {
            return carRepository.GetById(id);
        }

    }
}