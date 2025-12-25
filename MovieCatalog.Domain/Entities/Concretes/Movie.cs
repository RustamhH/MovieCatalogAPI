using MovieCatalog.Domain.Entities.Abstracts;

namespace MovieCatalog.Domain.Entities.Concretes
{
    public class Movie:BaseEntity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rating { get; set; }
    }
}
