
using Domain.Core.App.Requests.Data;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Users.Entity;
using Infra.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repo.App.Requests
{
    public class RequestRepository :IRequestRepository
    {
        private readonly AppDBContext _DBContext;
        public RequestRepository(AppDBContext appDB)
        {
            _DBContext = appDB;
        }
        public List<Request> GetAll()
        {
            return _DBContext.Requests.ToList();
        }
        public Request GetByPlate(string Plate)
        {
            return _DBContext.Requests.Where(x => x.RequestDay != null ).Include(x => x.Car).OrderByDescending(x => x.RequestDay).LastOrDefault(x => x.Plate == Plate);
        }

        public List<Request> GetAllUsersCars(User user)
        {
            return _DBContext.Requests.Where(x=>x.NationalCode==user.NationalCode).Include(x => x.Car).ToList();
        }

        public List<Request> PendingRequests()
        {
            return _DBContext.Requests.Include(x=>x.Car).Where(x => x.RequestDay == null).ToList();
        }

        public Request Get(int id) 
        {
            return _DBContext.Requests.Include(x=>x.Car).FirstOrDefault(x=>x.Id==id);
        }
        public List<Request> GetByDate(DateOnly date)
        {
            return _DBContext.Requests.Where(x=>x.RequestDay==date).ToList();
        }
        public bool Add(Request request)
        {
            _DBContext.Requests.Add(request);
            _DBContext.SaveChanges();
            return true;
        }
        public bool Update(Request request)
        {
            var oldreq = _DBContext.Requests.Include(x => x.Car).FirstOrDefault(x => x.Id == request.Id);
            oldreq.NationalCode = request.NationalCode;
            oldreq.PhoneNumber = request.PhoneNumber;
            oldreq.Address= request.Address;
            oldreq.RequestDay= request.RequestDay;
            oldreq.Plate = request.Plate;
            oldreq.CarId = request.CarId;
            _DBContext.Requests.Update(oldreq);
            _DBContext.SaveChanges();
            return true;
        }
        public bool DeleteRequest(int id)
        {
            var req= _DBContext.Requests.Include(x => x.Car).FirstOrDefault(x => x.Id == id);
            _DBContext.Remove(req);
            _DBContext.SaveChanges();
            return true;
        }
    }
}
