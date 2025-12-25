using Microsoft.EntityFrameworkCore;
using MovieCatalog.Application.Repositories.Common;
using MovieCatalog.Domain.Entities.Abstracts;
using MovieCatalog.Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Persistence.Repositories.Common
{
    public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new()
    {

        // Constructor

        public ReadGenericRepository(AppDbContext context) : base(context) { }

        // Methods

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return _table.Select(x=>x);
        }

        public async Task<IQueryable<T>?> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression);
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
