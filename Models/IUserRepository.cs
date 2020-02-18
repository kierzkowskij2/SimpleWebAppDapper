using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(long id);
    }
}
