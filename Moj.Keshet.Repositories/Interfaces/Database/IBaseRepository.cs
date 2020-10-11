using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moj.Keshet.Domain.ModelExtensions;
using Moj.Keshet.Domain.Models.Common;

namespace Moj.Keshet.Repositories.Interfaces
{
    public interface IBaseRepository : IDisposable
    {
        void ApplyTransactionTimeout(int miliseconds);

        Response SaveChanges();

        Response Add<T>(T entity, bool saveToDb = true) where T : class, IObjectWithChangeTracker;

        Response Update<T>(T entity, bool saveToDb = true) where T : class, IObjectWithChangeTracker;

        void Delete<T>(T entity, bool saveToDb = true) where T : class, IObjectWithChangeTracker;

        void DeleteByPredicate<T>(Expression<Func<T, bool>> predicate, bool saveToDb = true) where T : class, IObjectWithChangeTracker;

        void SetEntity<T>(T entity) where T : class, IObjectWithChangeTracker;

        Response SaveEntites<T>(List<T> entities, bool saveToDb = true)
            where T : class, IObjectWithChangeTracker;

        void UpdateEntities<T>(List<T> entities, Expression<Func<T, bool>> predicate, bool saveToDb = true) where T : class, IObjectWithChangeTracker, ICloneable;

        /// <summary>
        void UpdateEntitiesWithSelectiveClone<T>(List<T> entities, Expression<Func<T, bool>> predicate, bool saveToDb = true) where T : class, IObjectWithChangeTracker, ICloneable;
    }
}
