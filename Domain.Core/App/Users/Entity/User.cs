using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Users.Entity
{
    public class User
    {
        public int Id { get; set; }
        [Range(11, 11, ErrorMessage = "Please enter valid integer Number")]
        public string PhoneNumber { get; set; }
        [Range(10, 10, ErrorMessage = "Please enter valid integer Number")]
        public string NationalCode { get; set; }
 
        public String Password { get; set; }
        public string Address { get; set; }
        public UserRoleEnum Role { get; set; } = UserRoleEnum.user;
        public List<UserCar> UserCars { get; set; }


    }
}
