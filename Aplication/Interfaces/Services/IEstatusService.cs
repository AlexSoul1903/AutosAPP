using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;
using CarAlexCrud2000.Core.Aplication.ViewModels.Estatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.Interfaces.Services
{
    public interface IEstatusService: IGenericServices<SaveEstatusViewModel,EstatusViewModel>
    {
    }
}
