using Aplication.Repositories;
using CarAlexCrud2000.Core.Aplication.Helpers;
using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using CarAlexCrud2000.Core.Domain.Entities;
using DatabaseAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Infraestructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly CarContext _dbContext;

        public UserRepository(CarContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public override async Task<Users>AddAsync(Users user)
        {
            user.Password = PasswordEncryptation.ComputeSha256HashEncrypt(user.Password);
      
            await base.AddAsync(user);
            return user;
        }

        public  async Task<Users>LogAsync(LoginUserViewModel user)
        {
            string pass = user.Password = PasswordEncryptation.ComputeSha256HashEncrypt(user.Password);

            Users usData = await _dbContext.Set<Users>().FirstOrDefaultAsync(us=> us.Username ==user.Username && us.Password == pass);
            return usData;

        }

    }
}
