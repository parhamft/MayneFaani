using AppService.App.Requests;
using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.UserCars.AppServices;
using Domain.Core.App.Users.AppServices;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace EndPoint.Controllers
{
    public class UserCarsController : Controller
    {
        private readonly ICarAppService carAppService;
        private readonly IUserCarAppService userCarAppService;
        public UserCarsController(ICarAppService carApp, IUserCarAppService userCarApp)
        {
            carAppService = carApp;
            userCarAppService = userCarApp;
        }
        public IActionResult Index()
        {
            if (OnlineUser.CurrentUser == null)
            {
                return RedirectToAction("Index", "User");
            }
            var cars= carAppService.GetAllCars();
            return View(cars);
        }
        [HttpPost]
        public IActionResult AddCar(string Plate, int Car)
        {
            
           
            
            try
            {
                var car = carAppService.GetCarsById(Car);
                userCarAppService.AddUserCar(OnlineUser.CurrentUser, Plate, car);
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return RedirectToAction("Index");
            }
        }

    }
}
