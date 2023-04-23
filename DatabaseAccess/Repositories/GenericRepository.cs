using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Aplication.ViewModels.Autos;
using CarAlexCrud2000.Core.Domain.Entities;
using DatabaseAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repositories
{
    //Es un generic
    public class GenericRepository <Entidad> :IGenericRepositoryAsyncs<Entidad> where Entidad : class {  

        private readonly CarContext _dbContext;

        public GenericRepository(CarContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual async Task<Entidad> AddAsync(Entidad entidad)
        {

            await _dbContext.Set<Entidad>().AddAsync(entidad);
            await _dbContext.SaveChangesAsync();
            return entidad;
        }
        public virtual async Task DeleteAsync(Entidad entidad)
        {
        

            _dbContext.Remove(entidad);
            await _dbContext.SaveChangesAsync();
        }
        
        public virtual async Task <Entidad> GetByIdAsync(int Id)
        {

            return await _dbContext.Set<Entidad>().FindAsync(Id);

        }

        public virtual async Task<List<Entidad>> GetAllWithIncludeAsync(List<string> propiedades)
        {
            //Deferred Executions es que hasta que no se le exiga a entity framewor;
            //que me de un objeto IEnumerable es decir un listado de items entity framework
            //no ejecuta un query.

            var qr = _dbContext.Set<Entidad>().AsQueryable();
            foreach (string propiedead in propiedades)
            {
                qr = qr.Include(propiedead);
            }

            return await qr.ToListAsync();

        }

        public virtual async Task UpdateAsync(Entidad entidad)
        {

           _dbContext.Entry(entidad).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

 

        public virtual async Task<List<Entidad>> GetAllAsync()
        {
            return await _dbContext.Set<Entidad>().ToListAsync();


        }
    }
}
