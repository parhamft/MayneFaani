using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.UserCars.Services;
using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.UserCars.AppServices
{
    public interface IUserCarAppService
    {

        public List<UserCar> GetUserCars(User user);
        public UserCar GetUserCarById(int id);

        public String AddUserCar(User user, string Plate, Car car);
        public bool CheckIfValid(User user, int Id);
    }
}
