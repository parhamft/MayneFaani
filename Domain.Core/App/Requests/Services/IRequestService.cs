using Domain.Core.App.Requests.Data;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.UserCars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Requests.Services
{
    public interface IRequestService
    {
        public List<Request> GetPendingRequests();
        public bool CheckingTheCar(Request request);
        public bool AddRequest(Request request);
        public bool DeleteRequest(int id);
        public Request GetById(int id);
        public bool CheckingTheDate(Request request);
        public bool SettingDay(int id);

        
    }
}
