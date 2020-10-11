using Moj.Keshet.Domain.Interfaces;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Shared.Enums;

namespace Moj.Keshet.Services.Interfaces
{
    public interface ICommonListItemsRepository
    {
        ListItem[] GetListItems<T>(LookupTableName tableName) where T : class, IListItem;
        ListItem[] GetCommonSpecialListItems(LookupTableName tableName);
        ListItem[] GetListItemsNoWhere<T>(LookupTableName tableName) where T : class, IListItem;
    }
}
