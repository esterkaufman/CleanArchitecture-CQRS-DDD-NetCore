using Moj.Keshet.Shared.Enums;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Domain.ModelsDB;
using Moj.Keshet.Services.Interfaces.ListItems;

namespace Moj.Keshet.Services.Implementations.ListItems
{
    public class ProcessesListItemsProvider : CommonListItemsProvider, IProcessesListItemsProvider
    {
        IProcessesListItemsRepository _processesListItemsRepository;
        public ProcessesListItemsProvider(IProcessesListItemsRepository processesListItemsRepository) : base(processesListItemsRepository)
        {
            _processesListItemsRepository = processesListItemsRepository;
        }

       

        public ListItem[] GetProcessesListItems(LookupTableName tableName)
        {
            ListItem[] items = null;
            switch (tableName)
            {
                case LookupTableName.ProcessContactRoleTypes:

                    items = _processesListItemsRepository.GetListItems<ProcessContactRoleTypes>(tableName);
                    break;  
                case LookupTableName.RequestTypes:    
                case LookupTableName.RequestAppraisalTypes:
                case LookupTableName.RequestInspectionTypes:
                case LookupTableName.RequestObjectionTypes:
                    items = _processesListItemsRepository.GetProcessesSpecialListItems(tableName);
                    break;

                case LookupTableName.RequestActionTypes:
                    items = _processesListItemsRepository.GetListItemsNoWhere<RequestActionTypes>(tableName);
                    break;                    

                default:
                    items = GetCommonListItems(tableName);
                    break;
            }
            return items;
        }      



    }
}
