using Azure.Core.Pipeline;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Users.AppServices;
using Domain.Core.App.Users.Entity;
using Domain.Core.App.Users.Enums;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string NationalCode, string password)
        {
            try
            {
                OnlineUser.CurrentUser = _userAppService.Login(NationalCode, password);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return View("Index");
            }
            
            return View("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string nationalcode, string password, string phoneNumber, string Address)
        {
            try
            {
                TempData["Message"] = _userAppService.Register(nationalcode, password, phoneNumber, Address);
                TempData["AlertType"] = "success";
                return View();
            }

            catch (Exception ex) 
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return View("Index");
            }
        }
    }
}
