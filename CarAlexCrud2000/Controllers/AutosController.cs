using Aplication.Services;
using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;
using DatabaseAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.CarAlexCrud2000.Middlewares;

namespace CarAlexCrud2000.Controllers
{


    public class AutosController : Controller
    {

        private readonly IAutoservices _autosService;
        private readonly IEstatusService _estatusService;
        private readonly ValidarSession _validarSession;

        public AutosController(IAutoservices carServices, IEstatusService estatusService, ValidarSession validarSession)
        {

            _autosService = carServices;
            _estatusService = estatusService;
            _validarSession = validarSession;
        }

        public async Task<IActionResult> Index()
        {

            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }
            return View(await _autosService.GetAllViewModel());
        }

        public async Task <IActionResult> Create()
        {
            SaveAutoViewModel vm = new();
            vm.EstatusList = await _estatusService.GetAllViewModel();


            return View("SaveAuto", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAutoViewModel vm)
        {

            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            if (!ModelState.IsValid)
            {
                vm.EstatusList = await _estatusService.GetAllViewModel();
                return View ("SaveAuto", vm);

            }

            await _autosService.add(vm);

            return RedirectToRoute(new { controller = "Autos", action = "Index" });
        }





        public async Task <IActionResult> Edit(int Id)
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            SaveAutoViewModel vm = await _autosService.GetByIdSaveCarViewModel(Id);
            vm.EstatusList = await _estatusService.GetAllViewModel();
            return View("SaveAuto",vm);
        }




        [HttpPost]
        public async Task <IActionResult> Edit(SaveAutoViewModel vm)
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            if (!ModelState.IsValid)
            {
                vm.EstatusList = await _estatusService.GetAllViewModel();

                return View("SaveAuto", vm);

            }

            await _autosService.UpdateAsync(vm);
           
            return RedirectToRoute(new { controller = "Autos", action = "Index" });
        }


        public async Task<IActionResult> Delete(int Id)
        {

            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View(await _autosService.GetByIdSaveCarViewModel(Id));
        }




        [HttpPost]
        public async Task<IActionResult> Delete(SaveAutoViewModel vm)
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            await _autosService.Delete(vm);

            return RedirectToRoute(new { controller = "Autos", action = "Index" });
        }







    }

}
