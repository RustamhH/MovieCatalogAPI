using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Services;
using MovieCatalog.Infrastructure.Services.InternalServices;

namespace MovieCatalog.Infrastructure
{
    public static class RegisterServices
    {
        public static void AddInfrastructureRegister(this IServiceCollection services)
        {

            // Dependancy Injection

            services.AddScoped<IMovieService, MovieService>();

        }
    }
}
