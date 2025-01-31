using Domain.Core.App.RequestLogs.AppServices;
using Domain.Core.App.RequestLogs.Services;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.App.RequestLogs
{
    public class RequestLogAppService : IRequestLogAppService
    {
        private readonly IRequestLogService _requestLogService;
        public RequestLogAppService(IRequestLogService requestLog)
        {
            _requestLogService = requestLog;
        }
        public List<RequestLog> GetAllDisapprovedRequests(User user)
        {
            return _requestLogService.GetAllDisapprovedRequests(user);
        }
    }
}
