using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Opperators.Entity
{
    public class UserCar
    {
        public int Id{ get; set; }
        public string Plate { get; set; }
        public int CarId{ get; set; }
        public Car Car { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }


    }
}
