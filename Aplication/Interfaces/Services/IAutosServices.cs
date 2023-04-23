using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAlexCrud2000.Core.Aplication.ViewModels;
using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;

namespace CarAlexCrud2000.Core.Aplication.Interfaces.Services
{
    public interface IAutoservices: IGenericServices<SaveAutoViewModel, AutoViewModel> {

        Task<List<AutoViewModel>> GetAllViewModelFilter(FilterAutoViewModel filter);

    }

}

