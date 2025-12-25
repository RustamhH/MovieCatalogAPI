using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Services;
using MovieCatalog.Domain.DTOs;

namespace MovieCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetMoviesWithPagination")]
        public async Task<IActionResult> GetMoviesWithPagination([FromQuery] PaginationDTO paginationDTO)
        {
            var result = await _movieService.GetMoviesWithPagination(paginationDTO);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _movieService.GetAllMovies();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("GetMovieByTitle")]
        public async Task<IActionResult> GetMovieByTitle([FromQuery] string title)
        {
            var result = await _movieService.GetMovieByTitle(title);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("FilterMovieByGenre")]
        public async Task<IActionResult> FilterMovieByGenre([FromQuery] string genre)
        {
            var result = await _movieService.FilterMovieByGenre(genre);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("FilterMovieByReleaseYear")]
        public async Task<IActionResult> FilterMovieByReleaseYear([FromQuery] ushort year)
        {
            var result = await _movieService.FilterMovieByReleaseYear(year);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("SortMoviesByRating")]
        public async Task<IActionResult> SortMoviesByRating()
        {
            var result = await _movieService.SortMoviesByRating();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("SortMoviesByReleaseDate")]
        public async Task<IActionResult> SortMoviesByReleaseDate()
        {
            var result = await _movieService.SortMoviesByReleaseDate();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

    }
}
