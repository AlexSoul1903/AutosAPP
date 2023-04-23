using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Domain.Entities;
using DatabaseAccess.Context;


namespace Aplication.Repositories
{
    public class EstatusRepository : GenericRepository<Estatus>, IEstatusRepository
    {

        private readonly CarContext _dbContext;

        public EstatusRepository(CarContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }

    }
}

