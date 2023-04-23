using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.ViewModels.Estatus;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.CarAlexCrud2000.Middlewares;

namespace CarAlexCrud2000.Controllers
{
    public class EstatusController : Controller
    {

        private readonly IEstatusService _estatusService;
        private readonly ValidarSession _validarSession;

        public EstatusController(IEstatusService estatusServices, ValidarSession validarSession)
        {

            _estatusService = estatusServices;
            _validarSession = validarSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }
            return View(await _estatusService.GetAllViewModel());
        }

        public IActionResult Create()
        {


            return View("SaveEstatus", new SaveEstatusViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveEstatusViewModel vm)
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            if (!ModelState.IsValid)
            {
                return View("SaveEstatus", vm);

            }


            await _estatusService.add(vm);

            return RedirectToRoute(new { controller = "Estatus", action = "Index" });
        }





        public async Task<IActionResult> Edit(int Id)
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View("SaveEstatus", await _estatusService.GetByIdSaveCarViewModel(Id));
        }




        [HttpPost]
        public async Task<IActionResult> Edit(SaveEstatusViewModel vm)
        {

            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }
            if (!ModelState.IsValid)
            {
                return View("SaveEstatus", vm);

            }

            await _estatusService.UpdateAsync(vm);

            return RedirectToRoute(new { controller = "Estatus", action = "Index" });
        }


        public async Task<IActionResult> Delete(int Id)
        {

            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View(await _estatusService.GetByIdSaveCarViewModel(Id));
        }




        [HttpPost]
        public async Task<IActionResult> Delete(SaveEstatusViewModel vm)
        {
            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            await _estatusService.Delete(vm);

            return RedirectToRoute(new { controller = "Estatus", action = "Index" });
        }


    }
}
