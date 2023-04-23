using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.Interfaces.Services
{
    public interface IUserServices: IGenericServices<SaveUserViewModel,UserViewModel>
    {
        Task<UserViewModel> LoginAsync(LoginUserViewModel vm);
    }
}
