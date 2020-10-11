using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Domain.ModelsDB;
using Moj.Keshet.Services.Interfaces.ListItems;
using Moj.Keshet.Shared.Enums;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Implementations.ListItems
{
    public class ContactsListItemsProvider : CommonListItemsProvider,IContactsListItemsProvider
    {
        IContactsListItemsRepository _contactsListItemsRepository;
        public ContactsListItemsProvider(IContactsListItemsRepository contactsListItemsRepository):base(contactsListItemsRepository)
        {
            _contactsListItemsRepository = contactsListItemsRepository;
        }

        public Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId)
        {
           return this._contactsListItemsRepository.GetAppealOrganizationOfWorkOrderContact(WorkOrderContactId);
        }

        public ListItem[] GetContactsListItems(LookupTableName tableName)
        {

            ListItem[] items = null;
            switch (tableName)
            {
                case LookupTableName.ContactSubTypes:                    
                    items = _contactsListItemsRepository.GetListItemsNoWhere<ContactSubTypes>(tableName);
                    break;
             

                default:
                    items = GetCommonListItems(tableName);
                    break;
            }
            return items;
        }



    }
}
