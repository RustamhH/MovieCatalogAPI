

namespace MovieCatalog.Domain.Entities.Abstracts
{
    public interface IBaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Id { get; set; }

    }
}
