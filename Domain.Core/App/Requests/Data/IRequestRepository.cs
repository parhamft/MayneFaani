using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Requests.Data
{
    public interface IRequestRepository
    {
        public List<Request> GetAll();
        public Request Get(int id);
        public Request GetByPlate(string Plate);
        public List<Request> GetAllUsersCars(User user);
        public bool Add(Request request);
        public bool DeleteRequest(int id);
        public List<Request> PendingRequests();
        public bool Update(Request request);
        public List<Request> GetByDate(DateOnly date);
    }
}
