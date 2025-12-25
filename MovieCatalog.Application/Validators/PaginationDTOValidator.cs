using FluentValidation;
using MovieCatalog.Domain.DTOs;

namespace MovieCatalog.Application.Validators
{
    public class PaginationDTOValidator:AbstractValidator<PaginationDTO>
    {
        public PaginationDTOValidator()
        {
            RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("PageSize must be greater than 0.");
        }
    }
}
