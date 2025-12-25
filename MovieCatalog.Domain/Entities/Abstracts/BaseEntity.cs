using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Domain.Entities.Abstracts
{
    public abstract class BaseEntity : IBaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
