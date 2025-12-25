


using MovieCatalog.Application.Repositories.Movie;
using MovieCatalog.Application.Services;
using MovieCatalog.Application.Validators;
using MovieCatalog.Domain.DTOs;
using MovieCatalog.Domain.Entities.Common;
using MovieCatalog.Domain.Entities.Concretes;
using MovieCatalog.Domain.ViewModels;


namespace MovieCatalog.Infrastructure.Services.InternalServices
{
    public class MovieService : IMovieService
    {
        private readonly IReadMovieRepository _readMovieRepository;
        private readonly IWriteMovieRepository _writeMovieRepository;
        private readonly PaginationDTOValidator _validations;

        public MovieService(
            IReadMovieRepository readMovieRepository,
            PaginationDTOValidator validations , IWriteMovieRepository writeMovieRepository) 
        { 
            _readMovieRepository = readMovieRepository; 
            _validations = validations;
            _writeMovieRepository = writeMovieRepository;
            SeedMovies();
        }

        private void SeedMovies()
        {
            // Only seed if the database is empty
            if (_readMovieRepository.GetAllAsync().Result.Any())
                return;

            var movies = new List<Movie>
            {
                new Movie { Title="The Shawshank Redemption", Genre="Drama", Rating=9.3f, ReleaseDate=new DateTime(1994,9,23)},
                new Movie { Title="The Godfather", Genre="Crime", Rating=9.2f, ReleaseDate=new DateTime(1972,3,24)},
                new Movie { Title="The Dark Knight", Genre="Action", Rating=9.0f, ReleaseDate=new DateTime(2008,7,18)},
                new Movie { Title="Pulp Fiction", Genre="Crime", Rating=8.9f, ReleaseDate=new DateTime(1994,10,14)},
                new Movie { Title="Forrest Gump", Genre="Drama", Rating=8.8f, ReleaseDate=new DateTime(1994,7,6)},
                new Movie { Title="Inception", Genre="Sci-Fi", Rating=8.8f, ReleaseDate=new DateTime(2010,7,16)},
                new Movie { Title="Fight Club", Genre="Drama", Rating=8.8f, ReleaseDate=new DateTime(1999,10,15)},
                new Movie { Title="The Matrix", Genre="Sci-Fi", Rating=8.7f, ReleaseDate=new DateTime(1999,3,31)},
                new Movie { Title="Interstellar", Genre="Sci-Fi", Rating=8.6f, ReleaseDate=new DateTime(2014,11,7)},
                new Movie { Title="Parasite", Genre="Thriller", Rating=8.6f, ReleaseDate=new DateTime(2019,5,30)},
                new Movie { Title="Whiplash", Genre="Drama", Rating=8.5f, ReleaseDate=new DateTime(2014,10,10)},
                new Movie { Title="Gladiator", Genre="Action", Rating=8.5f, ReleaseDate=new DateTime(2000,5,5)},
                new Movie { Title="The Lion King", Genre="Animation", Rating=8.5f, ReleaseDate=new DateTime(1994,6,24)},
                new Movie { Title="The Prestige", Genre="Drama", Rating=8.5f, ReleaseDate=new DateTime(2006,10,20)},
                new Movie { Title="Joker", Genre="Crime", Rating=8.4f, ReleaseDate=new DateTime(2019,10,4)},
                new Movie { Title="Avengers: Infinity War", Genre="Action", Rating=8.4f, ReleaseDate=new DateTime(2018,4,27)},
                new Movie { Title="Django Unchained", Genre="Western", Rating=8.4f, ReleaseDate=new DateTime(2012,12,25)},
                new Movie { Title="The Wolf of Wall Street", Genre="Biography", Rating=8.2f, ReleaseDate=new DateTime(2013,12,25)},
                new Movie { Title="Shutter Island", Genre="Mystery", Rating=8.2f, ReleaseDate=new DateTime(2010,2,19)},
                new Movie { Title="Mad Max: Fury Road", Genre="Action", Rating=8.1f, ReleaseDate=new DateTime(2015,5,15)},
                new Movie { Title="Gravity", Genre="Sci-Fi", Rating=7.7f, ReleaseDate=new DateTime(2013,10,4)},
                new Movie { Title="The Social Network", Genre="Drama", Rating=7.7f, ReleaseDate=new DateTime(2010,10,1)},
                new Movie { Title="La La Land", Genre="Musical", Rating=8.0f, ReleaseDate=new DateTime(2016,12,9)},
                new Movie { Title="Blade Runner 2049", Genre="Sci-Fi", Rating=8.0f, ReleaseDate=new DateTime(2017,10,6)},
                new Movie { Title="Arrival", Genre="Sci-Fi", Rating=7.9f, ReleaseDate=new DateTime(2016,11,11)}
            };

            _writeMovieRepository.AddRangeAsync(movies);
        }

        public async Task<Result<IEnumerable<Movie>>> FilterMovieByGenre(string genre)
        {
            var result = await _readMovieRepository.GetByGenre(genre);
            return Result<IEnumerable<Movie>>.Success(result);
        }

        public async Task<Result<IEnumerable<Movie>>> FilterMovieByReleaseYear(ushort year)
        {
            var result = await _readMovieRepository.GetByReleaseYear(year);
            return Result<IEnumerable<Movie>>.Success(result);
        }

        public async Task<Result<IEnumerable<Movie>>> GetAllMovies()
        {
            var result = await _readMovieRepository.GetAllAsync();
            if (result is null) return Result<IEnumerable<Movie>>.Failure(new Error("NOT_FOUND", "No Movies Found"));
            return Result<IEnumerable<Movie>>.Success(result);
        }

        public async Task<Result<Movie>> GetMovieByTitle(string title)
        {
            var result = await _readMovieRepository.GetByTitle(title);
            return Result<Movie>.Success(result);
        }

        public async Task<Result<MovieVM>> GetMoviesWithPagination(PaginationDTO paginationDTO)
        {
            var validationResult = await _validations.ValidateAsync(paginationDTO);
            if (!validationResult.IsValid)
            {
                var resultval = Result<MovieVM>.Failure(
                    new Error("VALIDATION_ERROR", 
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));
                return resultval;
            }
            var result = await _readMovieRepository.GetByPagination(paginationDTO.PageNumber,paginationDTO.PageSize);
            if (result is null) return Result<MovieVM>.Failure(new Error("NOT_FOUND", "No Movies Found"));
            return Result<MovieVM>.Success(new MovieVM() { Movies=result,MovieCount=result.ToList().Count});
        }

        public async Task<Result<IEnumerable<Movie>>> SortMoviesByRating()
        {
            var result = await _readMovieRepository.GetAllAsync();
            if (result is null) return Result<IEnumerable<Movie>>.Failure(new Error("NOT_FOUND", "No Movies Found"));
            result.OrderByDescending(x=>x.Rating);
            return Result<IEnumerable<Movie>>.Success(result.OrderByDescending(x => x.Rating));

        }

        public async Task<Result<IEnumerable<Movie>>> SortMoviesByReleaseDate()
        {
            var result = await _readMovieRepository.GetAllAsync();
            if (result is null) return Result<IEnumerable<Movie>>.Failure(new Error("NOT_FOUND", "No Movies Found"));
            result.OrderByDescending(x => x.ReleaseDate);
            return Result<IEnumerable<Movie>>.Success(result.OrderByDescending(x => x.Rating));
        }
    }
}
