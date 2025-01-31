using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.RequestLogs.Data
{
    public interface IRequestLogsRepository
    {

        public List<RequestLog> GetAll();
        public RequestLog Get(int id);
        public List<RequestLog> GetAllUsersCars(User user);
        public bool Add(RequestLog requestLog);
    }
}
