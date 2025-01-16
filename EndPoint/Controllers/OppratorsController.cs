using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Users.Enums;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Approve(int id)
        {
            requestAppService.ApproveRequests(id);
            return RedirectToAction("Index");
        }

        public IActionResult Disapprove(int id)
        {
            requestAppService.Dissapprove(id);
            return RedirectToAction("Index");
        }
        
            
    }
}
