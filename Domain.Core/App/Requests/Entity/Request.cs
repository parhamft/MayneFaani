using Domain.Core.App.Cars.Entity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.App.Requests.Entity
{
    public class Request
    {
        public int Id { get; set; }
        [Length(8, 8, ErrorMessage = "Please enter a valid license plate")]
        public string Plate { get; set; }
        public DateOnly? RequestDay { get; set; }
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
