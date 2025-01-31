using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Opperators.Entity
{
    public class UserCar
    {
        public int Id{ get; set; }
        [Length(8, 8, ErrorMessage = "Please enter a valid license plate")]
        public string Plate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CarId{ get; set; }
        public Car? Car { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int UserId{ get; set; }
        public User? User { get; set; }


    }
}
