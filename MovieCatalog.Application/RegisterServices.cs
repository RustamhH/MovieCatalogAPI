using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Validators;
using FluentValidation;

namespace MovieCatalog.Application
{
    public static class RegisterServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(PaginationDTOValidator).Assembly, includeInternalTypes: true);
        }
    }
}
