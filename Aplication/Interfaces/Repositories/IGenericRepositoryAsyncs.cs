using CarAlexCrud2000.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.Interfaces.Repositories
{
    public interface IGenericRepositoryAsyncs<Entidad> where  Entidad: class
    {

        Task<Entidad>AddAsync(Entidad entidad);
        Task DeleteAsync(Entidad entidad);
        Task<Entidad> GetByIdAsync(int Id);
        Task<List<Entidad>> GetAllAsync();
        Task UpdateAsync(Entidad entidad);

        Task<List<Entidad>> GetAllWithIncludeAsync(List<string> propiedades);

    }
}
