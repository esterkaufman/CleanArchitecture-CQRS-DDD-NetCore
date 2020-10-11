using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Shared.Enums;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Interfaces.ListItems
{
    public interface IContactsListItemsProvider
    {
        ListItem[] GetContactsListItems(LookupTableName tableName);
        Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId);

    }
}
