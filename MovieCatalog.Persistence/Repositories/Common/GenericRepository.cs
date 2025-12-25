using Microsoft.EntityFrameworkCore;
using MovieCatalog.Application.Repositories.Common;
using MovieCatalog.Domain.Entities.Abstracts;
using MovieCatalog.Persistence.DbContext;

namespace MovieCatalog.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {

        // Fields

        protected DbSet<T> _table;
        protected readonly AppDbContext _context;

        // Constrctor

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
    }
}
