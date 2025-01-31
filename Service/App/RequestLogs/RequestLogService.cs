using Domain.Core.App.RequestLogs.Data;
using Domain.Core.App.RequestLogs.Services;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.App.RequestLogs
{
    
    public class RequestLogService : IRequestLogService
    {
        private readonly IRequestLogsRepository requestLogsRepository;
        public RequestLogService(IRequestLogsRepository requestLogs)
        {
            requestLogsRepository = requestLogs;
        }
        public bool AddRequestLog(Request request)
        {
            var reqlog = new RequestLog()
            {
                NationalCode = request.NationalCode,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Plate = request.Plate,
                CarId = request.CarId
            };
            return requestLogsRepository.Add(reqlog);
             
        }
        public List<RequestLog> GetAllDisapprovedRequests(User user)
        {
            return requestLogsRepository.GetAllUsersCars(user);
        }

    }
}
