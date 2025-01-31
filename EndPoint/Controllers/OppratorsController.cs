using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Users.Enums;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EndPoint.Controllers
{
    public class OppratorsController : Controller
    {
        private readonly IRequestAppService requestAppService;
        public OppratorsController(IRequestAppService requestApp)
        {
            requestAppService = requestApp;
        }
        public IActionResult Index()
        {
            if (OnlineUser.CurrentUser != null && OnlineUser.CurrentUser.Role == UserRoleEnum.admin)
            {
            var requests = requestAppService.GetPendingRequests();
            return View(requests);
            }
            return Redirect("/user");

        }
        [HttpGet]
        public IActionResult Approve(int id)
        {
            try
            {
                TempData["Message"] = requestAppService.ApproveRequests(id);
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return View("Index");
            }
        }

        public IActionResult Disapprove(int id)
        {
            
           
            try
            {
                TempData["Message"] = requestAppService.Dissapprove(id);
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
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
