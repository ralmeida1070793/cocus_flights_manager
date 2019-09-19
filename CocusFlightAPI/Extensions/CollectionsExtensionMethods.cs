using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class CollectionsExtensionMethods
    {
        public static void Add<TEntity>(this EntityCollection<TEntity> collection, TEntity entity)
        {
            collection.Entities.Add(entity);
        }

        public static void Remove<TEntity>(this EntityCollection<TEntity> collection, TEntity entity)
        {
            collection.Entities.Remove(entity);
        }
    }
}
