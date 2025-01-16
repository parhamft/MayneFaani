using Domain.Core.App.Users.Data;
using Domain.Core.App.Users.Entity;
using Domain.Core.App.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Users.Services
{
    public interface IUserService
    {
        public User Login(string nationalcode, string password);
        public string Register(string nationalcode, string password, string PhoneNumber, string Address);
        public bool CheckRole(User user);
    }
}
