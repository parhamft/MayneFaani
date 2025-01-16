using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Requests.Entity
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateOnly RequestDay { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateOnly CreationYear { get; set; }
        public string Address { get; set; }


    }
}
