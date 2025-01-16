using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.UserCars.Data
{
    public interface IUserCarRepository
    {
        public List<UserCar> GetAll();
        public UserCar Get(int id);
        public UserCar GetByPlate(string plate);
        public bool Add(UserCar userCar);
        public List<UserCar> GetAllUsersCar(User user);
    }
}
