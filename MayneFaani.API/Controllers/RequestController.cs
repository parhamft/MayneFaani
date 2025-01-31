using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.RequestLogs.AppServices;
using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.UserCars.AppServices;
using Infra.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MayneFaani.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IUserCarAppService carAppService;
        private readonly ICarAppService _carAppService;
        private readonly IRequestAppService requestAppService;
        private readonly IConfiguration Configuration;
        private readonly IRequestLogAppService requestLogAppService;
        private readonly IUserCarAppService userCarAppServiceX;

        public RequestController(IUserCarAppService userCarAppService, ICarAppService carApp, IRequestAppService requestApp, IRequestLogAppService requestLog, IUserCarAppService userCarAppService1)
        {
            carAppService = userCarAppService;
            _carAppService = carApp;
            requestAppService = requestApp;
            userCarAppServiceX = userCarAppService1;
            requestLogAppService = requestLog;
        }
        [HttpPost("send Request")]
        public void SendRequest(Request req)
        {

                requestAppService.AddRequest(req);



        }
        [HttpPost("LoggedInSendRequest")]
        public void LoggedInRequest(int Car)
        {
            if (OnlineUser.CurrentUser == null)
            {
                throw new Exception("not logged in");
            }
            var car = userCarAppServiceX.GetUserCarById(Car);
                var req = new Request() { Address = OnlineUser.CurrentUser.Address, Plate = car.Plate, CarId = car.CarId, NationalCode = OnlineUser.CurrentUser.NationalCode, PhoneNumber = OnlineUser.CurrentUser.PhoneNumber };
                requestAppService.AddRequest(req);
        }
        [HttpGet("RequestHistory")]
        public List<Request> PastRequests()
        {
            if (OnlineUser.CurrentUser == null)
            {
                throw new Exception("not logged in");
            }
            return requestAppService.GetPastRequests(OnlineUser.CurrentUser);

        }
        [HttpGet("DissaprovedRequests")]
        public List<RequestLog> DisapprovedRequests()
        {
            if (OnlineUser.CurrentUser == null)
            {
                throw new Exception("not logged in");
            }
            return requestLogAppService.GetAllDisapprovedRequests(OnlineUser.CurrentUser);

        }
    }
}
