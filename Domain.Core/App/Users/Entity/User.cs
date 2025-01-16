using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Users.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
 
        public String Password { get; set; }
        public string Address { get; set; }
        public UserRoleEnum Role { get; set; } = UserRoleEnum.user;
        public List<UserCar> UserCars { get; set; }


    }
}
