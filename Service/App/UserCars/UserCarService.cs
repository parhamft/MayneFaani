using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Opperators.Entity;
using Domain.Core.App.UserCars.Data;
using Domain.Core.App.UserCars.Services;
using Domain.Core.App.Users.Entity;

namespace Service.App.UserCars
{
    public class UserCarService: IUserCarService
    {
        private readonly IUserCarRepository _userCarRepository;
        public UserCarService(IUserCarRepository userCarRepository)
        {
            _userCarRepository = userCarRepository;
        }
        public List<UserCar> GetUserCars(User user)
        {
            return _userCarRepository.GetAllUsersCar(user);

        }
        public UserCar GetUserCarById(int id)
        {
            return _userCarRepository.Get(id);
        }
        public String AddUserCar(User user, string Plate, Car car)
        {
            var usercar = _userCarRepository.GetByPlate(Plate);
            if (usercar != null)
            {
                throw new Exception("A Car with that licanceplate exists");
            }
            var newcar = new UserCar()
            {
                Plate = Plate,

                CarId = car.Id,
                UserId = user.Id
            };
            _userCarRepository.Add(newcar);
            return "Car Has Been Added";
        }
        public bool CheckIfValid(User user, int Id)
        {
            var Car = _userCarRepository.GetAllUsersCar(user).FirstOrDefault(car => car.Id == Id);
            if (Car == null)
            {
                throw new Exception("That Car Does not exist!");
            }
            if (DateTime.Now.Year - Car.Car.CreationYear.Year > 5)
            {
                throw new Exception("We Will No Longer Work On your Car"); 
            }
            return true;

        }

    }
}

