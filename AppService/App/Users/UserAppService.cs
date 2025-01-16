using Domain.Core.App.Users.AppServices;
using Domain.Core.App.Users.Entity;
using Domain.Core.App.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.App.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }
        public User Login(string nationalcode, string password)
        {
            return _userService.Login(nationalcode, password);
        }

        public string Register(string nationalcode, string password, string PhoneNumber, string Address)
        {
            return _userService.Register(nationalcode, password, PhoneNumber, Address); 
        }

        public bool CheckRole(User user)
        {
            return _userService.CheckRole(user);
        }
    }
}
