using Aplication.Services;
using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.ViewModels;
using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;
using CarAlexCrud2000.Models;
using DatabaseAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CarAlexCrud2000.Middlewares;

namespace CarAlexCrud2000.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutoService _autosServices;
        private readonly EstatusService _estatusService;
        private readonly ValidarSession _validarSession;

        public HomeController(IAutoservices autosServices, IEstatusService estatusService, ValidarSession validarSession)
        {
            _autosServices = (AutoService)autosServices;
            _estatusService = (EstatusService)estatusService;
            _validarSession = validarSession;
        }

        public async Task <IActionResult> Index(FilterAutoViewModel vm)
        {


            if (!_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            ViewBag.EstatusList = await _estatusService.GetAllViewModel(); 
            return View(await _autosServices.GetAllViewModelFilter(vm));
        }


      

     
    }
}
