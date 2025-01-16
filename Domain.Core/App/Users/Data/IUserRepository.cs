using Domain.Core.App.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.Users.Data
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User GetByNC(string NationalCode);
        public bool Delete(int id);
        public bool Add(User user);
        public bool Update(User User);
    }
}
