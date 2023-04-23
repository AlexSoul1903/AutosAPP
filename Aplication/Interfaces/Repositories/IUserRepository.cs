using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using CarAlexCrud2000.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepositoryAsyncs<Users>
    {

        Task<Users> LogAsync(LoginUserViewModel user);
    }
}
