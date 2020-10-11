using Moj.Keshet.Domain.Models.ListItems;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Interfaces.ListItems
{
    public interface IContactsListItemsRepository :ICommonListItemsRepository
    {
        Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId);
    }
}
