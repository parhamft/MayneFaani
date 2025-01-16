using Domain.Core.App.Cars.Entity;
using Domain.Core.App.Users.Data;
using Domain.Core.App.Users.Entity;
using Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repo.App.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _DBContext;
        public UserRepository(AppDBContext appDB)
        {
            _DBContext = appDB;
        }
        public List<Domain.Core.App.Users.Entity.User> GetAll()
        {
            return _DBContext.Users.ToList();
        }
        public Domain.Core.App.Users.Entity.User GetById(int id)
        {
            return _DBContext.Users.FirstOrDefault(x => x.Id == id);
        }
        public bool Delete(int id)
        {
            var user = _DBContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null) { return false; }
            _DBContext.Users.Remove(user);
            _DBContext.SaveChanges();
            return true;

        }
        public bool Add(Domain.Core.App.Users.Entity.User user)
        {
            _DBContext.Users.Add(user);
            _DBContext.SaveChanges();
            return true;
        }
        public bool Update(Domain.Core.App.Users.Entity.User User)
        {
            var OldUser = _DBContext.Users.FirstOrDefault(x => x.Id == User.Id);
            OldUser.NationalCode=User.NationalCode;
            OldUser.Password=User.Password;
            OldUser.PhoneNumber=User.PhoneNumber;
            OldUser.Address=User.Address;
            _DBContext.SaveChanges();
            return true;
        }

        public Domain.Core.App.Users.Entity.User GetByNC(string NationalCode)
        {
            return _DBContext.Users.FirstOrDefault(x => x.NationalCode == NationalCode);
        }
    }
}
