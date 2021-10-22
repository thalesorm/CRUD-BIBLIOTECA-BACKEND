using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _baseRepository;

        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository)
        {
            _baseRepository = baseRepository;
            _userRepository = userRepository;
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.Login(email, password);
            return user;
        }
    }
}
