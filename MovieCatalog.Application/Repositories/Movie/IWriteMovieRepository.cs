using MovieCatalog.Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Application.Repositories.Movie
{
    public interface IWriteMovieRepository:IWriteGenericRepository<Domain.Entities.Concretes.Movie>
    {

    }
}
