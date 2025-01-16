using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Requests.Services;
using Domain.Core.App.UserCars.AppServices;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class RequestController : Controller
    {
        private readonly IUserCarAppService carAppService;
        private readonly ICarAppService _carAppService;
        private readonly IRequestAppService requestAppService;
        private readonly IConfiguration Configuration;
        private readonly IRequestService requestService;
        private readonly IUserCarAppService userCarAppServiceX;

        public RequestController(IUserCarAppService userCarAppService, ICarAppService carApp, IRequestAppService requestApp, IUserCarAppService userCarAppService1)
        {
            carAppService = userCarAppService;
            _carAppService = carApp;
            requestAppService = requestApp;
            userCarAppServiceX = userCarAppService1;
        }
        public IActionResult Index()
        {
            if (OnlineUser.CurrentUser != null)
            {

                return RedirectToAction("LoggedInRequest");
            }

            var cars = _carAppService.GetAllCars();
            return View(cars);
        }
        [HttpPost]
        public IActionResult SendRequest(string Plate, int Car, string nationalcode, string phoneNumber, string Address)
        {
            try
            {
                var req = new Request() { Address = Address, Plate = Plate, CarId = Car, NationalCode = nationalcode, PhoneNumber = phoneNumber };
                requestAppService.AddRequest(req);
                return Redirect("/Home");

            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return RedirectToAction("Index");
            }
        }

        public IActionResult LoggedInRequest()
        {
            var cars = carAppService.GetUserCars(OnlineUser.CurrentUser);
            return View(cars);
        }
        [HttpPost]
        public IActionResult LoggedInRequest(int Car)
        {
            try
            {
                var car = userCarAppServiceX.GetUserCarById(Car);
                var req = new Request() { Address = OnlineUser.CurrentUser.Address, Plate = car.Plate, CarId = car.CarId, NationalCode = OnlineUser.CurrentUser.NationalCode, PhoneNumber = OnlineUser.CurrentUser.PhoneNumber };
                requestAppService.AddRequest(req); 
                return Redirect("/Home");
            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return RedirectToAction("LoggedInRequest");
            }
        }
    }
}
