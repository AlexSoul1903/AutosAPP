using CarAlexCrud2000.Core.Aplication.Helpers;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using Microsoft.AspNetCore.Http;

namespace WebApp.CarAlexCrud2000.Middlewares
{
    public class ValidarSession
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidarSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public bool VerificaUsuario()
        {

            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");

            if(userViewModel == null)
            {

                return false;
            }

            return true;

        }
    }
}
