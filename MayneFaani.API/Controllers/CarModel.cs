using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.Cars.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MayneFaani.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModel : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ICarAppService carAppService;
        private readonly String Key;
        public CarModel(ICarAppService carApp, IConfiguration configuration)
        {
            carAppService = carApp;
            Configuration = configuration;
            Key = Configuration.GetSection("APIKey:Key").Value;
        }

        [HttpPost("GetCarById")]
        public Car GetById([FromHeader] string apikey, int id)
        {
            if (apikey == Key)
            {
                return carAppService.GetCarsById(id);
            }
            throw new Exception("ApiKey Is Wrong");
             
        }
        [HttpGet("GetAllCars")]
        public List<Car> GetCars([FromHeader] string apikey)
        {
            if (apikey == Key)
            {
                return carAppService.GetAllCars();
            }
            throw new Exception("ApiKey Is Wrong");

        }
        [HttpPost("AddCar")]
        public void Add([FromHeader] string apikey, Car car)
        {

            if (apikey == Key)
            {
                carAppService.AddCar(car);
                return;
            }
            throw new Exception("ApiKey Is Wrong");
        }
        [HttpPost("UpdateCar")]
        public void Update([FromHeader] string apikey, Car car)
        {

            if (apikey == Key)
            {
                carAppService.Update(car);
                return;
            }
            throw new Exception("ApiKey Is Wrong");
        }
        [HttpPost("Delete")]
        public void Delete([FromHeader] string apikey, int id)
        {

            if (apikey == Key)
            {
                carAppService.Delete(id);
                return;
            }
            throw new Exception("ApiKey Is Wrong");
        }

    }
}
