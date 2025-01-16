using Domain.Core.App.Users.Data;
using Domain.Core.App.Users.Entity;
using Domain.Core.App.Users.Enums;
using Domain.Core.App.Users.Services;

namespace Service.App.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Login(string nationalcode,string password)
        {
            var user = _userRepository.GetByNC(nationalcode);
            if (user == null) 
            {
                throw new Exception("User Does not exist");
            }
            if (user.Password != password)
            {
                throw new Exception("Password Is incorrect");
            }
            return user;
        }
        public string Register(string nationalcode, string password, string PhoneNumber, string Address)
        {
            var Checkuser = _userRepository.GetByNC(nationalcode);
            if (Checkuser != null)
            {
                throw new Exception("That NationalCode Is Taken");
            }
            User user= new User { NationalCode=nationalcode, Password = password, PhoneNumber = PhoneNumber, Address = Address };
            _userRepository.Add(user);
            return "User Registered succesfuly";
        }
        public bool CheckRole(User user)
        {
            if (user.Role == UserRoleEnum.admin) 
            {
                return true;
            }        
            return false;
        }

    }
}
