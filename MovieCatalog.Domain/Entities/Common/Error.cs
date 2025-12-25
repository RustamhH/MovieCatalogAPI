using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Domain.Entities.Common
{
    public sealed record Error(string? StatusCode, string? Description = null)
    {
        public static readonly Error None = new(string.Empty);
        public static implicit operator Result(Error error) => Result.Failure(error);
    }

}
