using CarAlexCrud2000.Core.Aplication.Interfaces.Repositories;
using CarAlexCrud2000.Core.Domain.Entities;
using DatabaseAccess.Context;


namespace Aplication.Repositories
{
    public class AutosRepository : GenericRepository<Autos>, IAutoRepository
    {

        private readonly CarContext _dbContext;

        public AutosRepository(CarContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
        }

    }

