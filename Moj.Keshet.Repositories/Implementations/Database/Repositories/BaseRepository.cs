using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Domain.ModelExtensions;
using Moj.Keshet.Domain.Models.Common;
using Moj.Keshet.Repositiories.Extensions;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository 
    {
        #region Core

        #region Core Public

        /// <summary>
        /// Sets the internal database command timeout in miliseconds
        /// </summary>
        /// <param name="miliseconds"></param>
        public void ApplyTransactionTimeout(int miliseconds)
        {
            _db.ApplyTransactionTimeout(miliseconds);
        }

        /// <summary>
        /// Triggers the DbContext overriden implementation of SaveChanges
        /// </summary>
        /// <returns>An instance of Response with the affected updated/inserted entities in the DbContext</returns>
        public Response SaveChanges()
        {
            return _db.SaveChanges();
        }

        /// <summary>
        /// Tracks the entity in the DbContext for insert and optionally (by default) triggers the DbContext overriden implementation of SaveChanges
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entity">The entity instance to be inserted</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        /// <returns>An instance of Response with the affected updated/inserted entities in the DbContext</returns>
        public Response Add<T>(T entity, bool saveToDb = true) where T : class, IObjectWithChangeTracker
        {
            _db.Add(entity);
            return saveToDb ? _db.SaveChanges() : new Response();
        }

        /// <summary>
        /// Tracks the entity in the DbContext for update and optionally (by default) triggers the DbContext overriden implementation of SaveChanges
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entity">The entity instance to be updated</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        /// <returns>An instance of Response with the affected updated/inserted entities in the DbContext</returns>
        public Response Update<T>(T entity, bool saveToDb = true) where T : class, IObjectWithChangeTracker
        {
            _db.Update(entity);
            return Save(saveToDb);
        }

        /// <summary>
        /// Tracks the entity in the DbContext for delete and optionally (by default) triggers the DbContext overriden implementation of SaveChanges
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entity">The entity instance to be deleted</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        public void Delete<T>(T entity, bool saveToDb = true) where T : class, IObjectWithChangeTracker
        {
            _db.Remove(entity);
            Save(saveToDb);
        }

        /// <summary>
        /// Tracks a set of entities in the DbContext for delete and optionally (by default) triggers the DbContext overriden implementation of SaveChanges
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="predicate">A where lambda expression to select the set of relevant entities. Normally that would express a foreign key condition</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        public void DeleteByPredicate<T>(Expression<Func<T, bool>> predicate, bool saveToDb = true) where T : class, IObjectWithChangeTracker
        {
            _db.Set<T>().Where(predicate).ToList().ForEach(MarkEntityForDelete);
            Save(saveToDb);
        }

        /// <summary>
        /// Tracks the entity in the DbContext according to its preset ChangeTracker state
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entity">The entity instance to be tracked</param>
        public void SetEntity<T>(T entity) where T : class, IObjectWithChangeTracker
        {
            _db.ApplyChanges<T>(entity);
        }

        /// <summary>
        /// Tracks a list of entities in the DbContext according to their preset ChangeTracker state
        /// and optionally (by default) triggers the DbContext overriden implementation of SaveChanges
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entities">The entity instances to be processed</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        /// <returns>An instance of Response with the affected updated/inserted entities in the DbContext</returns>
        public Response SaveEntites<T>(List<T> entities, bool saveToDb = true)
            where T : class, IObjectWithChangeTracker
        {
            return SaveList<T>(entities, saveToDb);
        }

        /// <summary>
        /// Tracks a list of entities in the DbContext according to their preset ChangeTracker state
        /// and optionally (by default) triggers the DbContext overriden implementation of SaveChanges.
        /// This method offers also a two phase update that involves delete+insert. To use that option pass a predicate for deletion,
        /// It is based on the CLONED ENTITY metodology.
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entities">The entity instances to be processed</param>
        /// <param name="predicate">An optional where lambda expression to select the set of relevant entities for deletion. Normally that would express a foreign key condition</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        public void UpdateEntities<T>(List<T> entities, Expression<Func<T, bool>> predicate, bool saveToDb = true) where T : class, IObjectWithChangeTracker, ICloneable
        {
            if (predicate != null)
            {
                DeleteByPredicate<T>(predicate, saveToDb);
            }
            if (entities.Any())
            {
                var cloneEntities = CloneList(entities); // ?
                SaveEntites(cloneEntities, saveToDb);
            }
        }

        /// <summary>
        /// Tracks a list of entities in the DbContext according to their preset ChangeTracker state
        /// and optionally (by default) triggers the DbContext overriden implementation of SaveChanges.
        /// It offers a differential treatment for new and non-new entities.
        /// This method offers also a two phase update that involves delete+insert. To use that option pass a predicate for deletion,
        /// It is based on the CLONED ENTITY metodology.
        /// </summary>
        /// <typeparam name="T">An entity type, must be a class instance implementing IObjectWithChangeTracker</typeparam>
        /// <param name="entities">The entity instances to be processed</param>
        /// <param name="predicate">An optional where lambda expression to select the set of relevant entities for deletion. Normally that would express a foreign key condition</param>
        /// <param name="saveToDb">Indication for immediate exceution on SaveChanges. The default is true. Pass the value of false for delayed save, make sure to call it within your scope</param>
        public void UpdateEntitiesWithSelectiveClone<T>(List<T> entities, Expression<Func<T, bool>> predicate, bool saveToDb = true) where T : class, IObjectWithChangeTracker, ICloneable
        {
            if (predicate != null)
            {
                DeleteByPredicate<T>(predicate, saveToDb);
            }
            if (entities.Any())
            {
                var cloneEntities = CloneNonAddedList(entities);
                SaveEntites(cloneEntities, saveToDb);
            }
        }

        #endregion Public Methdos

        #region Private Methdos

        private List<T> CloneList<T>(ICollection<T> list) where T : ICloneable, IObjectWithChangeTracker
        {
            var cloneList = new List<T>();
            foreach (var item in list)
            {
                cloneList.Add((T)item.Clone());
            }
            return cloneList;
        }

        private List<T> CloneNonAddedList<T>(ICollection<T> list) where T : ICloneable, IObjectWithChangeTracker
        {
            var cloneList = new List<T>();
            foreach (var item in list)
            {
                if (item.ChangeTracker.State == TrackedState.Added)
                    cloneList.Add(item);
                else
                    cloneList.Add((T)item.Clone());
            }
            return cloneList;
        }

        private Response SaveList<T>(List<T> newEntitiesList, bool saveToDb = true) where T : class, IObjectWithChangeTracker
        {
            if (!newEntitiesList.Any())
                return new Response();

            TrackList<T>(newEntitiesList);

            if (!saveToDb) return new Response();
            return _db.SaveChanges();
        }

        private void TrackList<T>(List<T> newEntitiesList) where T : class, IObjectWithChangeTracker
        {
            foreach (var item in newEntitiesList)
            {
                switch (item.ChangeTracker.State)
                {
                    case TrackedState.Added:
                        Add(item, false);
                        break;
                    case TrackedState.Modified:
                        Update(item, false);
                        break;
                    case TrackedState.Deleted:
                        Delete(item, false);
                        break;
                    default:
                        break;
                }
            }
        }

        private void MarkEntityForDelete<T>(T entity) where T : class, IObjectWithChangeTracker
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }

        private Response Save(bool saveToDb = true)
        {
            return saveToDb ? _db.SaveChanges() : new Response();
        }

        #endregion Core Public

        #endregion Core
    }
}
