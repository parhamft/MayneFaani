using AppService.App.Cars;
using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.UserCars.AppServices;
using Infra.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MayneFaani.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCarsController : ControllerBase
    {
        private readonly ICarAppService carAppService;
        private readonly IUserCarAppService userCarAppService;

        public UserCarsController(ICarAppService carApp, IUserCarAppService userCarApp)
        {
            carAppService = carApp;
            userCarAppService = userCarApp;
        }
        [HttpPost("AddCar")]
        public void AddCar(UserCar model)
        {
            if (OnlineUser.CurrentUser==null)
            {
                throw new Exception("not logged in");
            }
                var car = carAppService.GetCarsById(model.CarId);
                userCarAppService.AddUserCar(OnlineUser.CurrentUser, model.Plate, car);
        }
        [HttpGet("usersCars")]
        public List<UserCar> GetAllCars()
        {
            if (OnlineUser.CurrentUser == null)
            {
                throw new Exception("not logged in");
            }
            var cars = userCarAppService.GetUserCars(OnlineUser.CurrentUser);
            return cars;
        }

    }
}
