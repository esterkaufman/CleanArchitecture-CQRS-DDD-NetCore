using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Domain.ModelExtensions;

namespace Moj.Keshet.Repositiories.Extensions
{
    public static class EntityFrameworkExtensions
    {
        /// <summary>
        /// ApplyChanges takes the changes in a connected set of entities and applies them to an ObjectContext.
        /// </summary>
        /// <typeparam name="TEntity">Expected type of the ObjectSet</typeparam>
        /// <param name="db">The DbContext to which changes will be applied.</param>
        /// <param name="dbSet">The DbSet of the type to which changes will be applied.</param>
        /// <param name="entity">The entity serving as the entry point of the object graph that contains changes.</param>
        public static void ApplyChangesEx<TEntity>(this DbSet<TEntity> dbSet, DbContext db, TEntity entity) where TEntity : class, IObjectWithChangeTracker
        {
            if (db == null) throw new ArgumentNullException("db");
            if (dbSet == null) throw new ArgumentNullException("dbSet");

            switch (entity.ChangeTracker.State)
            {
                case TrackedState.Added:
                    dbSet.Add(entity);
                    break;
                case TrackedState.Deleted:
                    db.Entry(entity).State = EntityState.Deleted;
                    break;
                case TrackedState.Modified:
                    db.Entry(entity).State = EntityState.Modified;
                    break;
                default:
                    return;
            }
        }

        public static void ApplyChanges<TEntity>(this DbContext db, TEntity entity) where TEntity : class, IObjectWithChangeTracker
        {
            if (db == null) throw new ArgumentNullException("db");

            switch (entity.ChangeTracker.State)
            {
                case TrackedState.Added:
                    db.Set<TEntity>().Add(entity);
                    break;
                case TrackedState.Deleted:
                    db.Entry(entity).State = EntityState.Deleted;
                    break;
                case TrackedState.Modified:
                    db.Entry(entity).State = EntityState.Modified;
                    break;
                default:
                    return;
            }
        }

       
    }
    public static class LinqExt
    {
        public static IEnumerable<TResult> LeftOuterJoin<TLeft, TRight, TKey, TResult>(this IEnumerable<TLeft> left, IEnumerable<TRight> right, Func<TLeft, TKey> leftKey, Func<TRight, TKey> rightKey,
            Func<TLeft, TRight, TResult> result)
        {
            return left.GroupJoin(right, leftKey, rightKey, (l, r) => new { l, r })
                 .SelectMany(
                     o => o.r.DefaultIfEmpty(),
                     (l, r) => new { lft = l.l, rght = r })
                 .Select(o => result.Invoke(o.lft, o.rght));
        }
    }
}
