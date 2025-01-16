using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.UserCars.Data;
using Domain.Core.App.Users.Entity;
using Infra.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repo.App.UserCars 
{
    public class UserCarRepository : IUserCarRepository
    {
        private readonly AppDBContext _DBContext;
        public UserCarRepository(AppDBContext appDB)
        {
            _DBContext = appDB;
        }
        public List<UserCar> GetAll()
        {
            return _DBContext.UserCars.ToList();
        }
        public UserCar Get(int id)
        {
            return _DBContext.UserCars.FirstOrDefault(x=>x.Id==id);
        }
        public UserCar GetByPlate(string plate)
        {
            return _DBContext.UserCars.Include(x=>x.Car).FirstOrDefault(x => x.Plate == plate);
        }
        public List<UserCar> GetAllUsersCar(Domain.Core.App.Users.Entity.User user)
        {
            return _DBContext.UserCars.Where(x => x.UserId == user.Id).ToList();
        }
        public bool Add(UserCar userCar)
        {
            _DBContext.UserCars.Add(userCar);
            _DBContext.SaveChanges();
            return true;
        }
    }
}
