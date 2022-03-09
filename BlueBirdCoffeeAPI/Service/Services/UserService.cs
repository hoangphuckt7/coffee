using Data.AppException;
using Data.DataAccessLayer;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IUserService
    {
        void Test();
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Test()
        {
            var user = _dbContext.Users.FirstOrDefault();

            if(user == null)
            {
                user = new User() { Email = "123456@email.com"};

                _dbContext.Add(user);
                _dbContext.SaveChanges();
            }

            user = _dbContext.Users.FirstOrDefault();
            throw new AppException(user.Email);
        }
    }
}
