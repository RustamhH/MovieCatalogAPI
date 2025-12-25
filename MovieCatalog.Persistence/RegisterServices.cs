using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Repositories.Movie;
using MovieCatalog.Application.Services;
using MovieCatalog.Persistence.DbContext;
using MovieCatalog.Persistence.Repositories.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Persistence
{
    public static class RegisterServices
    {
        public static void AddPersistenceRegister(this IServiceCollection services)
        {

            // Dependancy Injection

            services.AddDbContext<AppDbContext>(options => {
                ConfigurationBuilder configurationBuilder = new();
                var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();
                options.UseSqlServer(builder.GetConnectionString("Default"));
            });



            // Register all Repository in Persistence


            // All Read Repository

            services.AddScoped<IReadMovieRepository, ReadMovieRepository>();

            // All Write Repository

            services.AddScoped<IWriteMovieRepository, WriteMovieRepository>();

        }
    }
}
