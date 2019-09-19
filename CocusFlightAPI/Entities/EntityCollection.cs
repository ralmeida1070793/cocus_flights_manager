using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Utility class to handle paged entity collections
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityCollection<TEntity> : IEntityCollection<TEntity>
    {
        public EntityCollection()
        { }

        public int Total { get; set; }
        public IList<TEntity> Entities { get; set; }
    }
}
