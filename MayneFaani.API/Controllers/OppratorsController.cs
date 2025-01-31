using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Enums;
using Infra.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace MayneFaani.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OppratorsController : ControllerBase
    {
        private readonly IRequestAppService requestAppService;
        public OppratorsController(IRequestAppService requestApp)
        {
            requestAppService = requestApp;
        }
        [HttpGet("PendingRequest")]
        public List<Request> GetRequests()
        {
            if (OnlineUser.CurrentUser != null && OnlineUser.CurrentUser.Role == UserRoleEnum.admin)
            {
                var requests = requestAppService.GetPendingRequests();
                return requests;
            }
            throw new Exception("you dont have permission");
        }
        [HttpPost("Approve")]
        public void Approve(int id)
        {
            if (OnlineUser.CurrentUser != null && OnlineUser.CurrentUser.Role == UserRoleEnum.admin)
            {
                requestAppService.ApproveRequests(id);
                return;
            }
            

            throw new Exception("you dont have permission");
        }
        [HttpPost("Dissaprove")]
        public void Disapprove(int id)
        {
            if (OnlineUser.CurrentUser != null && OnlineUser.CurrentUser.Role == UserRoleEnum.admin)
            {
                requestAppService.Dissapprove(id);
                return;
            }


            throw new Exception("you dont have permission");


        }

    }
}
