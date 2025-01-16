﻿using Domain.Core.App.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Cars.Services
{
    public interface ICarService
    {
        public List<Car> GetAllCars();
        public Car GetCarsById(int id);
    }
}
