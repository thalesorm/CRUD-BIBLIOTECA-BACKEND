using Data.Context;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {

        }

        public User Login(string email, string password)
        {
            var obj = CurrentSet
                        .Where(x => x.Email == email && x.Password == password)
                        .FirstOrDefault();
            return obj; 
        }
    }
}
