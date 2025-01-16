using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.UserCars.AppServices;
using Domain.Core.App.UserCars.Services;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.App.UserCars
{
    public class UserCarAppService : IUserCarAppService
    {
        private readonly IUserCarService _userCarService;
        public UserCarAppService(IUserCarService userCarService)
        {
            _userCarService = userCarService;
        }
        public List<UserCar> GetUserCars(User user)
        {
            return _userCarService.GetUserCars(user);
        }
        public UserCar GetUserCarById(int id)
        {
            return _userCarService.GetUserCarById(id);
        }
        public String AddUserCar(User user, string Plate, Car car)
        {
            return _userCarService.AddUserCar(user, Plate, car);
        }
        public bool CheckIfValid(User user, int Id)
        {
            return _userCarService.CheckIfValid(user, Id);
        }
    }
}
