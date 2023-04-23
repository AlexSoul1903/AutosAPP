using CarAlexCrud2000.Core.Aplication.Helpers;
using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using CarAlexCrud2000.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class AutoService: IAutoservices
    {

        private readonly IAutoRepository _autoRepository;

        private readonly UserViewModel _userViewModel;

        private readonly IHttpContextAccessor _httpContextAccessor;

        
        public AutoService(IAutoRepository autoRepository, IHttpContextAccessor httpContextAccessor)
        {

            _autoRepository = autoRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");
        }

        public async Task<SaveAutoViewModel> add(SaveAutoViewModel vm)
        {

           
            Autos auto =new();

            auto.ImgRuta = vm.ImgRuta;
            auto.Year = vm.Year;
            auto.miEstatusId = vm.miEstatusId;
            auto.Modelo = vm.Modelo;
            auto.Marca = vm.Marca;
            auto.miUserId = _userViewModel.Id;

           auto= await _autoRepository.AddAsync(auto);

            SaveAutoViewModel autoVm = new SaveAutoViewModel();

            autoVm.IdAuto = auto.IdAuto;
            autoVm.ImgRuta = auto.ImgRuta;
            autoVm.Year = auto.Year;
            autoVm.miEstatusId = auto.miEstatusId;
            autoVm.Modelo = auto.Modelo;
            autoVm.Marca = auto.Marca;


            return autoVm;
        }

        public async Task<SaveAutoViewModel> GetByIdSaveCarViewModel(int Id)
        {


            var auto = await _autoRepository.GetByIdAsync(Id);

            SaveAutoViewModel vm = new();

            vm.IdAuto = auto.IdAuto;    
            vm.ImgRuta = auto.ImgRuta;
            vm.Year = auto.Year;
            vm.miEstatusId =  auto.miEstatusId;
           vm.Modelo = auto.Modelo;
            vm.Marca = auto.Marca;
 
            return vm; 

        }

        public async Task UpdateAsync(SaveAutoViewModel vm)
        {

            
           
            Autos auto = await _autoRepository.GetByIdAsync(vm.IdAuto);
            auto.IdAuto = vm.IdAuto;
            auto.ImgRuta = vm.ImgRuta;
            auto.Year = vm.Year;
            auto.miEstatusId = vm.miEstatusId;
            auto.Modelo = vm.Modelo;
            auto.Marca = vm.Marca;



            await _autoRepository.UpdateAsync(auto);


        }

        public async Task Delete(SaveAutoViewModel vm)
        {

            Autos auto = new();
            auto.IdAuto = vm.IdAuto;
            auto.ImgRuta = vm.ImgRuta;
            auto.Year = vm.Year;
            auto.miEstatusId = vm.miEstatusId;
            auto.Modelo = vm.Modelo;
            auto.Marca = vm.Marca;

            await _autoRepository.DeleteAsync(auto);

        }



        public async Task<List<AutoViewModel>> GetAllViewModel()
        {

            var autoList = await _autoRepository.GetAllWithIncludeAsync(new List<string> {"estatus"});

            return autoList.Where(auto => auto.miUserId==_userViewModel.Id).Select(auto => new AutoViewModel
            {
                IdAuto = auto.IdAuto,
                ImgRuta = auto.ImgRuta,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                Year = auto.Year,
                EstatusDescripcion = auto.estatus.Descripcion

            }).ToList();




        }

        public async Task<List<AutoViewModel>> GetAllViewModelFilter(FilterAutoViewModel filter)
        {

            var autoList = await _autoRepository.GetAllWithIncludeAsync(new List<string> { "estatus" });

            var Lista= autoList.Where(auto => auto.miUserId == _userViewModel.Id).Select(auto => new AutoViewModel
            {
                IdAuto = auto.IdAuto,
                ImgRuta = auto.ImgRuta,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                Year = auto.Year,
                EstatusDescripcion = auto.estatus.Descripcion,
               IdEstatus=auto.miEstatusId
            }).ToList();

            if (filter.IdEstatus == null)
            {


            }
            else
            {
                Lista = Lista.Where(auto => auto.IdEstatus == filter.IdEstatus.Value).ToList();

            }


            return Lista;



        }

   
    }

}