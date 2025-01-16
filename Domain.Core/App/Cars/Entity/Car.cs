using Domain.Core.App.Opperators.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Cars.Entity
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Company{ get; set; }
        public DateOnly CreationYear { get; set; }
        public List<UserCar> UserCars { get; set; }
    }
}

