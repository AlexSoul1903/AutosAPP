using Aplication.Services;
using CarAlexCrud2000.Core.Aplication.Helpers;
using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CarAlexCrud2000.Middlewares;

namespace CarAlexCrud2000.Controllers
{


    public class UserController : Controller
    {

        private readonly IUserServices _userService;
        private readonly ValidarSession _validarSession;

        public UserController(IUserServices userServices, ValidarSession validarSession)
        {

            _userService = userServices;
            _validarSession = validarSession;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserViewModel logVm)
        {
            if (_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });


            }


            if (!ModelState.IsValid)
            {

                return View(logVm);

            }

            UserViewModel usVM = await _userService.LoginAsync(logVm);
            if (usVM == null)
            {
                ModelState.AddModelError("errorDeValidacion","Los dantos son incorrectos");

                return View(logVm);

            }
            else
            {
                HttpContext.Session.Set<UserViewModel>("usuario",usVM);
                return RedirectToRoute(new { controller = "Home", action = "Index" });


            }


      
        }

        public IActionResult Register()
        {
            if (_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });


            }
            return View("Register");
        }

        public IActionResult CerrarSession()
        {
            HttpContext.Session.Remove("usuario");

            return RedirectToRoute(new { controller = "User", action = "Index" });

        }


        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel RegisUservm)
        {
            if (_validarSession.VerificaUsuario())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });


            }
            if (!ModelState.IsValid)
            {

                return View("Register", RegisUservm);

            }

            SaveUserViewModel userVm = await _userService.add(RegisUservm);

            if(userVm.Id!=0 && userVm != null)
            {

                userVm.ImgRoute = SubirArchivo(RegisUservm.File, userVm.Id);


                await _userService.UpdateAsync(userVm);

            }



            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        private  string SubirArchivo(IFormFile file, int id)
        {
            //Obtener la ruta del directorio

            string BaseRute = "/css/assets/imgs/UserPhoto/" + id;

            string rute = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + BaseRute);


            //Crar folder en caso de que no exista

            if (!Directory.Exists(rute))
            {

                Directory.CreateDirectory(rute);

            }

            //Obtener la ruta del archivo
            Guid guid = Guid.NewGuid();

            FileInfo infofile = new(file.FileName);

            string FN = guid + infofile.Extension;

            string finalroute = Path.Combine(rute, FN);

            using (var stream = new FileStream(finalroute, FileMode.Create))
            {

                file.CopyTo(stream);

            }

                return Path.Combine(BaseRute,FN);

        }



    }

}
