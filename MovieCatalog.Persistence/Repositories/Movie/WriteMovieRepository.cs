using MovieCatalog.Application.Repositories.Movie;
using MovieCatalog.Persistence.DbContext;
using MovieCatalog.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Persistence.Repositories.Movie
{
    public class WriteMovieRepository:WriteGenericRepository<Domain.Entities.Concretes.Movie>,IWriteMovieRepository
    {
        public WriteMovieRepository(AppDbContext appDbContext):base(appDbContext)
        {
            
        }


    }
}
