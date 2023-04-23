using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.Interfaces.Services
{
    public interface IGenericServices<ViewModel, ListViewModel>
        where ViewModel : class
        where ListViewModel : class
    {

        Task<ViewModel> add(ViewModel vm);
        Task<ViewModel> GetByIdSaveCarViewModel(int Id);
        Task UpdateAsync(ViewModel vm);
        Task Delete(ViewModel vm);
        Task<List<ListViewModel>> GetAllViewModel();
      



    }
}
