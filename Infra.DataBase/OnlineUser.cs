using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase
{
    public static class OnlineUser
    {
        public static User? CurrentUser{ get; set; }
    }
}
