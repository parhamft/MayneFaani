using Domain.Core.App.Cars.Entity;

namespace Domain.Core.App.Requests.Entity
{
    public class Request
    {
        public int Id { get; set; }

        public string Plate { get; set; }
        public DateOnly? RequestDay { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public string Address { get; set; }


    }
}
