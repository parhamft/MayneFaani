using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Requests.Services;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Requests.AppServices
{
    public interface IRequestAppService
    {
        public List<Request> GetPendingRequests();
        public List<Request> GetPastRequests(User user);
        public string AddRequest(Request request);
        public string ApproveRequests(int id);
        public string Dissapprove(int id);
    }
}
