using MovieCatalog.Domain.DTOs;
using MovieCatalog.Domain.Entities.Common;
using MovieCatalog.Domain.Entities.Concretes;
using MovieCatalog.Domain.ViewModels;

namespace MovieCatalog.Application.Services
{
    public interface IMovieService
    {
        Task<Result<Movie>> GetMovieByTitle(string title);
        Task<Result<MovieVM>> GetMoviesWithPagination(PaginationDTO paginationDTO);
        Task<Result<IEnumerable<Movie>>> GetAllMovies();
        Task<Result<IEnumerable<Movie>>> FilterMovieByGenre(string genre);
        Task<Result<IEnumerable<Movie>>> FilterMovieByReleaseYear(ushort year);
        Task<Result<IEnumerable<Movie>>> SortMoviesByReleaseDate();
        Task<Result<IEnumerable<Movie>>> SortMoviesByRating();
    }
}
