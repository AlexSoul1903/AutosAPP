using CarAlexCrud2000.Core.Aplication.Helpers;
using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.ViewModels.Estatus;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using CarAlexCrud2000.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class EstatusService : IEstatusService
    {

        private readonly IEstatusRepository _estatusRepository;
        private readonly UserViewModel _userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EstatusService(IEstatusRepository estatusRepository, IHttpContextAccessor httpContextAccessor)
        {

            _estatusRepository = estatusRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");
        }

        public async Task<SaveEstatusViewModel> add(SaveEstatusViewModel vm)
        {



           Estatus estatus = new();

            estatus.Descripcion = vm.Descripcion;
          
            estatus= await _estatusRepository.AddAsync(estatus);

            SaveEstatusViewModel Estatusvm = new();
           
            Estatusvm.IdEstatus = estatus.IdEstatus;
            Estatusvm.Descripcion = estatus.Descripcion;

            return Estatusvm;
        }

        public async Task<SaveEstatusViewModel> GetByIdSaveCarViewModel(int Id)
        {


            var estatus = await _estatusRepository.GetByIdAsync(Id);

            SaveEstatusViewModel vm = new();
            vm.IdEstatus = estatus.IdEstatus;
            vm.Descripcion = estatus.Descripcion;
          
            return vm;

        }

        public async Task UpdateAsync(SaveEstatusViewModel vm)
        {



            Estatus estatus = await _estatusRepository.GetByIdAsync(vm.IdEstatus);
            estatus.Descripcion = vm.Descripcion;
            estatus.IdEstatus = vm.IdEstatus;
           



            await _estatusRepository.UpdateAsync(estatus);


        }

        public async Task Delete(SaveEstatusViewModel vm)
        {


            Estatus estatus= new();
            estatus.Descripcion = vm.Descripcion;
            estatus.IdEstatus= vm.IdEstatus;
            

            await _estatusRepository.DeleteAsync(estatus);

        }



        public async Task<List<EstatusViewModel>> GetAllViewModel()
        {

            var estatusList = await _estatusRepository.GetAllWithIncludeAsync(new List<string> { "Autos" });

            return estatusList.Select(estatus => new EstatusViewModel
            {
                IdEstatus = estatus.IdEstatus,
                Descripcion = estatus.Descripcion,
                CantidadAutosEst = estatus.Autos.Where(auto=> auto.miUserId==_userViewModel.Id).Count()


            }).ToList();




        }
    }

}