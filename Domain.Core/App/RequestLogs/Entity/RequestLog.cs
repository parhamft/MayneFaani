using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Requests.Entity
{
    public class RequestLog
    {
        public int Id { get; set; }
        [Length(8,8,ErrorMessage ="Please enter a valid license plate")]
        public string Plate { get; set; }
        public DateOnly RequestDay { get; set; }
        [Range(11, 11, ErrorMessage = "Please enter valid integer Number")]
        public string PhoneNumber { get; set; }
        [Range(10, 10, ErrorMessage = "Please enter valid integer Number")]
        public string NationalCode { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CarId { get; set; }
        public Car? Car { get; set; }
        [Required]
        public string Address { get; set; }


    }
}
