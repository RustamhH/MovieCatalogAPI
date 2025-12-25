

using MovieCatalog.Domain.Entities.Abstracts;

namespace MovieCatalog.Application.Repositories.Common
{
    public interface IReadGenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {

        // Methods

        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>?> GetAllAsync();
    }
}
