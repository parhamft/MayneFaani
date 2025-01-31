using Domain.Core.App.Cars.Data;
using Domain.Core.App.Cars.Entity;
using Infra.DataBase;

namespace Infra.repo.App.Cars
{
    public class CarRepositor : ICarRepository
    {
        private readonly AppDBContext _DBContext;
        public CarRepositor(AppDBContext appDB)
        {
            _DBContext = appDB;
        }
        public List<Car> GetAll()
        {
            return _DBContext.Cars.ToList();
        }

        public Car GetById(int id)
        {
            return _DBContext.Cars.FirstOrDefault(x => x.Id == id);
        }
        public bool Delete(int id)
        {
            var car = _DBContext.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null) { return false; }
            _DBContext.Cars.Remove(car);
            _DBContext.SaveChanges();
            return true;

        }
        public bool Add(Car car)
        {
            _DBContext.Cars.Add(car);
            _DBContext.SaveChanges();
            return true;
        }
        public bool Update(Car car)
        {
            var OldCar = _DBContext.Cars.FirstOrDefault(x=>x.Id==car.Id);
            OldCar.Model=car.Model;
            OldCar.Company = car.Company;
            OldCar.CreationYear = car.CreationYear;

            _DBContext.SaveChanges();
            return true;
        }
        

    }
}
