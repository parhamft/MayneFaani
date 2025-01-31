using Domain.Core.App.RequestLogs.Data;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using Infra.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repo.App.RequestLogs
{
    public class RequestLogsRepository : IRequestLogsRepository
    {
        private readonly AppDBContext _DBContext;
        public RequestLogsRepository(AppDBContext appDB)
        {
            _DBContext = appDB;
        }
        public List<RequestLog> GetAll()
        {
            return _DBContext.requestLogs.ToList();
        }
        public RequestLog Get(int id)
        {
            return _DBContext.requestLogs.FirstOrDefault(x => x.Id == id);
        }
        public List<RequestLog> GetAllUsersCars(User user)
        {
            return _DBContext.requestLogs.Where(x => x.NationalCode == user.NationalCode).Include(x => x.Car).ToList();
        }

        public bool Add(RequestLog requestLog)
        {
            _DBContext.requestLogs.Add(requestLog);
            _DBContext.SaveChanges();
            return true;
        }
        
    }
}
