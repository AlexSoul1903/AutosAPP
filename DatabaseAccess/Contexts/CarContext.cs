using CarAlexCrud2000.Core.Aplication.Helpers;
using CarAlexCrud2000.Core.Aplication.ViewModels.Users;
using CarAlexCrud2000.Core.Domain.Common;
using CarAlexCrud2000.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DatabaseAccess.Context
{
    public class CarContext:DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
 

        //El constructor de CarContext exigue el parametro de DbContext options.
        //Se usa base (option) para pasarle las opciones a las clase padre.

        //En cada lugar en el cual yo use CarContext se va a inyectar de manera automatica 
        public CarContext(DbContextOptions<CarContext> option,IHttpContextAccessor httpContextAccessor): base(option) {

            _httpContextAccessor = httpContextAccessor;
         
        }
       
        public DbSet<Autos> Autos { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Users> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken()) {
            UserViewModel vm = new();
      
            vm =_httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");
            
            foreach (var entrada in ChangeTracker.Entries<AuditBaseEntity>())
            {

                switch (entrada.State)
                {
                    case EntityState.Added:
                        entrada.Entity.CreatedDate = DateTime.Now;
                        if (vm != null)
                        {
                            entrada.Entity.CreatedBy = "Nombre:" + vm.Nombre + ", Username: " + vm.Username;
                        }
                        else
                        {
                            entrada.Entity.CreatedBy = "Admin";

                        }
                        break;

                        case EntityState.Modified:

                        entrada.Entity.ModifiedDate = DateTime.Now;
                        if (vm != null)
                        {
                            entrada.Entity.ModifiedBy = "Nombre: " + vm.Nombre + ", Username: " + vm.Username;
                        }
                        else
                        {
                            entrada.Entity.ModifiedBy = "Admin";
                        }
                        break;

                }

            }

            //Se cumple el principio de sustitucion de Livskov
           return base.SaveChangesAsync(cancellation);
        }
        //Configuraciones de las propiedades con Fluent Api.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region tablas

            modelBuilder.Entity<Autos>().ToTable("Autos");
            modelBuilder.Entity<Estatus>().ToTable("Estatus");
            modelBuilder.Entity<Users>().ToTable("Users");
            #endregion


            #region "Claves Primarias"


            modelBuilder.Entity<Autos>().HasKey(autos => autos.IdAuto);
            modelBuilder.Entity<Estatus>().HasKey(estatus => estatus.IdEstatus);
            modelBuilder.Entity<Users>().HasKey(user => user.Id);

            #endregion

            #region "Relaciones"

            modelBuilder.Entity<Estatus>().HasMany<Autos>(estatus => estatus.Autos)
                .WithOne(autos => autos.estatus)
                .HasForeignKey(autos => autos.miEstatusId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>().HasMany<Autos>(user=> user.autos)
               .WithOne(autos => autos.user)
               .HasForeignKey(autos => autos.miUserId).OnDelete(DeleteBehavior.Cascade);



            #endregion


            #region "Configuracion de propiedades"

            #region "Autos"

            //Se dice que las propiedades son requeridas
            //Requeridas de autos
            modelBuilder.Entity<Autos>().Property(auto => auto.Modelo).IsRequired();
            modelBuilder.Entity<Autos>().Property(auto => auto.Marca).IsRequired();
            modelBuilder.Entity<Autos>().Property(auto => auto.Year).IsRequired();

            //Requeridas de User
            modelBuilder.Entity<Users>().Property(user => user.Nombre).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Users>().Property(user => user.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Users>().Property(user => user.Password).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Edad).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Users>().Property(user => user.Phone).IsRequired();

            #endregion

            #region "Estatus"



            #endregion


            #endregion
        }


    }
}
