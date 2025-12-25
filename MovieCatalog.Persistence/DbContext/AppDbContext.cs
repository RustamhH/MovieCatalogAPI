

using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities.Concretes;

namespace MovieCatalog.Persistence.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        // Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        // Tables

        public virtual DbSet<Movie> Movies { get; set; }

    }
}
