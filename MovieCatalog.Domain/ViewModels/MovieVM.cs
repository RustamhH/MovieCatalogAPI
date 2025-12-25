using MovieCatalog.Domain.Entities.Concretes;

namespace MovieCatalog.Domain.ViewModels
{
    public class MovieVM
    {
        public IEnumerable<Movie> Movies { get; set; }
        public int MovieCount { get; set; }
    }
}
