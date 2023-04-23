using CarAlexCrud2000.Core.Domain.Entities;
using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatabaseAccess.Context;
using Aplication.Repositories;
using CarAlexCrud2000.Infraestructure.Persistence.Repositories;

namespace CarAlexCrud2000.Infraestructure.Persistence
{
    public static class ServiceRegristration
    {
        //Extension Method es una aplicacion del patron de diseno Decorator que lo que hace es extender la posibilidad de los paquetes
        public static void addPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Contexts"




            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {

                services.AddDbContext<CarContext>(options => options.UseInMemoryDatabase("AppDb"));

            }
            else
            {

                //El objeto de configuration permite acceder a las opciones del appsettings
                services.AddDbContext<CarContext>(options => options.UseSqlServer(configuration.GetConnectionString
                    ("DefaultConnection"), migration => migration.MigrationsAssembly(typeof(CarContext).Assembly.FullName)));
            }

            #endregion

            #region "Repositories"
            services.AddTransient(typeof(IGenericRepositoryAsyncs<>),typeof(GenericRepository<>));
            services.AddTransient<IAutoRepository,AutosRepository>();
            services.AddTransient<IEstatusRepository, EstatusRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            #endregion


        }


    }
}
