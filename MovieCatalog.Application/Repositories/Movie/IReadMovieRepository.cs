using MovieCatalog.Application.Repositories.Common;

namespace MovieCatalog.Application.Repositories.Movie
{
    public interface IReadMovieRepository:IReadGenericRepository<Domain.Entities.Concretes.Movie>
    {
        Task<Domain.Entities.Concretes.Movie> GetByTitle(string title);
        Task<IEnumerable<Domain.Entities.Concretes.Movie>> GetByReleaseYear(ushort year);
        Task<IEnumerable<Domain.Entities.Concretes.Movie>> GetByGenre(string genre);
        Task<IEnumerable<Domain.Entities.Concretes.Movie>> GetByPagination(int pageNumber,int pageSize);
    }
}
