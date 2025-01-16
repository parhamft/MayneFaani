using Domain.Core.App.Cars.Entity;
using Domain.Core.App.RequestLogs.Services;
using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Requests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.App.Requests
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _requestService;
        private readonly IRequestLogService requestLogService;

        public RequestAppService(IRequestService requestService, IRequestLogService request)
        {
            _requestService = requestService;
            requestLogService = request;

        }
        public List<Request> GetPendingRequests()
        {
            return _requestService.GetPendingRequests();
        }
        public string AddRequest(Request request)
        {
            _requestService.CheckingTheCar(request);
            _requestService.CheckingTheDate(request);
            _requestService.AddRequest(request);
            return "Request Sent";
        }
        public string ApproveRequests(int id)
        {
            _requestService.SettingDay(id);
            return "date has been set succesfully";
        }
        public string Dissapprove(int id)
        {
            Request req = _requestService.GetById(id);

            requestLogService.AddRequestLog(req);

            _requestService.DeleteRequest(id);
            return "Dissaproved";
        }
    }
}
