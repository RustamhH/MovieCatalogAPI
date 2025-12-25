using Microsoft.EntityFrameworkCore;
using MovieCatalog.Application.Repositories.Movie;
using MovieCatalog.Persistence.DbContext;
using MovieCatalog.Persistence.Repositories.Common;

namespace MovieCatalog.Persistence.Repositories.Movie
{
    public class ReadMovieRepository : ReadGenericRepository<Domain.Entities.Concretes.Movie>, IReadMovieRepository
    {

        public ReadMovieRepository(AppDbContext appDbContext):base(appDbContext) { }

        public async Task<IEnumerable<Domain.Entities.Concretes.Movie>> GetByGenre(string genre)
        {
            return await _table.Where(x => string.Equals(x.Genre,genre)).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Concretes.Movie>> GetByPagination(int pageNumber, int pageSize)
        {
            return await _table.AsNoTracking().Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Concretes.Movie>> GetByReleaseYear(ushort year)
        {
            return await _table.Where(x => x.ReleaseDate.Year==year).ToListAsync();
        }

        public async Task<Domain.Entities.Concretes.Movie> GetByTitle(string title)
        {
            return await _table.Where(x => string.Equals(x.Title, title)).FirstOrDefaultAsync();

        }
    }
}
