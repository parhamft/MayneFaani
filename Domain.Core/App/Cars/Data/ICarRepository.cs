using Domain.Core.App.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Cars.Data
{
    public interface ICarRepository
    {
        public List<Car> GetAll();

        public Car GetById(int id);
        public bool Delete(int id);
        public bool Add(Car car);
        public bool Update(Car car);
    }
}
