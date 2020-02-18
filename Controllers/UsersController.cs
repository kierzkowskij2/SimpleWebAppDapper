using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApp.Models;

namespace SimpleWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
           return _userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public User GetUser(int id)
        {
           return _userRepository.GetUser((long)id);
        }

        [HttpPost]
        public bool CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        [HttpPut("{id}")]
        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
