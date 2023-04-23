using Aplication.Services;
using CarAlexCrud2000.Core.Aplication.Interfaces.Services;
using CarAlexCrud2000.Core.Aplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAlexCrud2000.Infraestructure.Persistence
{
    public static class ServiceRegristration
    {
        //Extension Method es una aplicacion del patron de diseno Decorator que lo que hace es extender la posibilidad de los paquetes
        public static void addApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {


            #region "Services"

            services.AddTransient<IAutoservices, AutoService>();
            services.AddTransient<IEstatusService, EstatusService>();
            services.AddTransient<IUserServices, UserService>();
            #endregion


        }


    }
}


