using Moj.Keshet.Domain.Interfaces;
using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Domain.ModelsDB;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Shared.Enums;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository : ICommonListItemsRepository
    {

        #region Members

        private static ConcurrentDictionary<LookupTableName, ListItem[]> _store = new ConcurrentDictionary<LookupTableName, ListItem[]>();


        #endregion

        #region Methods


        public ListItem[] GetListItems<T>(LookupTableName tableName) where T : class, IListItem
        {
            return GetOrAddInStore<T, string>(tableName,
               (x => x.IsActive),
               (x => x.Name),
               (a => new ListItem { Id = a.Id, Name = a.Name, IsActive = a.IsActive, ParentId = a.ParentId })
               );
        }

        public ListItem[] GetListItemsNoWhere<T>(LookupTableName tableName) where T : class, IListItem
        {
            return GetOrAddInStore<T, string>(tableName,
               (x => true),
               (x => x.Name),
               (a => new ListItem { Id = a.Id, Name = a.Name, IsActive = a.IsActive, ParentId = a.ParentId })
               );

        }
       
        private ListItem[] GetOrAddInStore<T, TOrderByType>(LookupTableName tableName, Func<T, bool> wherePredicate, Func<T, TOrderByType> orderByPredicate, Func<T, ListItem> selector) where T : class
        {
            return _store.GetOrAdd(tableName, (key) =>
            {
                _logger.Trace($"Requesting code table {key}");
                var query = _db.GetQuery<T>()
                .Where(wherePredicate);
                if (typeof(IListItem).IsAssignableFrom(typeof(T)))
                {
                    //IListItem implemants calculated fields. so can't reach them in sql query
                    query = query.ToList();
                }
                var result = query
                .OrderBy(orderByPredicate)
                .Select(selector)
                .ToArray();
                if (result == null || result.Length == 0)
                {
                    _logger.Error($"ListItemsRepository.GetListItems error: Table {key} was not initialized for code-pair cache!");
                    throw new NotImplementedException($"Table {key} was not initialized for code-pair cache!");
                }

                return result;
            });
        }


        public void ListItemCacheClear()
        {
            _store = new ConcurrentDictionary<LookupTableName, ListItem[]>();
        }
        #endregion

        #region Common listItems with special get
        public ListItem[] GetCommonSpecialListItems(LookupTableName tableName)
        {
            switch (tableName)
            {
                case LookupTableName.AllDistricts:
                case LookupTableName.InternalDistricts:
                case LookupTableName.ExternalDistricts:
                    return GetDistricts(tableName);
                case LookupTableName.AppealOrganizations:
                    return GetOrAddInStore<AppealOrganizations, string>(tableName,
                        (x => x.IsActive),
                        (x => x.AppealOrganizationName),
                        (x => new AppealOrganizationItem
                        {
                            Id = x.AppealOrganizationID,
                            Name = x.AppealOrganizationName,
                            IsActive = x.IsActive,  
                            IsIsraelLandAuthority = x.AppealOrganizationID == (byte)AppealOrganizationsEnum.IsraelLandAuthority
                        }));
                case LookupTableName.RequestsStatus:
                    return GetOrAddInStore<RequestsStatusTypes, string>(tableName,
                        (x => x.IsActive && (!x.IsGis.HasValue || x.IsGis.Value == false)),
                        (x => x.RequestStatusTypeName),
                        (x => new ListItemToolTip
                        {
                            Id = x.RequestStatusTypeId,
                            Name = x.RequestStatusTypeName,
                            Tooltip = x.ToolTip
                        }));                   

                default:
                    throw new ApplicationException($"{ToString()} error:There is no table with name {tableName} ");

            }

        }

        private ListItem[] GetDistricts(LookupTableName tableName)
        {

            var isAll = tableName == LookupTableName.AllDistricts;
            var isExternal = tableName == LookupTableName.ExternalDistricts;
            return GetOrAddInStore<Districts, string>(tableName,
                (x => x.IsActive && (isAll || (!x.IsExternal.HasValue || x.IsExternal.Value == isExternal))),
                (x => x.DistrictName),
                (x => new ListItem
                {
                    Id = x.DistrictID,
                    Name = x.DistrictName,
                    IsActive = x.IsActive
                }));

        }
        #endregion


    }
}
