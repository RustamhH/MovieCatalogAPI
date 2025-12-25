namespace MovieCatalog.Domain.DTOs
{
    public class PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}
