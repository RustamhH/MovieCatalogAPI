
using MovieCatalog.Domain.Entities.Abstracts;

namespace MovieCatalog.Application.Repositories.Common
{
    public interface IGenericRepository<T> where T : IBaseEntity, new()
    {

    }
}
