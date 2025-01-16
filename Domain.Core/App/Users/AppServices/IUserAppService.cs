using Domain.Core.App.Users.Entity;
using Domain.Core.App.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Users.AppServices
{
    public interface IUserAppService
    {
        public User Login(string nationalcode, string password);

        public string Register(string nationalcode, string password, string PhoneNumber, string Address);

        public bool CheckRole(User user);
    }
}
