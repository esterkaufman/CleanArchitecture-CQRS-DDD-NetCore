using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Domain.ModelsDB;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Shared.Enums;
using System;

namespace Moj.Keshet.Services.Implementations.ListItems
{
    public abstract class CommonListItemsProvider
    {
        protected readonly ICommonListItemsRepository _commonListItemsRepository;
        public CommonListItemsProvider(ICommonListItemsRepository commonListItemsRepository)
        {
            _commonListItemsRepository = commonListItemsRepository;
        }

        public ListItem[] GetCommonListItems(LookupTableName tableName)
        {

            ListItem[] items = null;
            switch (tableName)
            {
                case LookupTableName.AllDistricts:
                case LookupTableName.InternalDistricts:
                case LookupTableName.ExternalDistricts:
                case LookupTableName.AppealOrganizations:
                case LookupTableName.RequestsStatus:
                    items = _commonListItemsRepository.GetCommonSpecialListItems(tableName);
                    break;
                  
                case LookupTableName.Blocks:
                    items = _commonListItemsRepository.GetListItems<Blocks>(tableName);
                    break;

                case LookupTableName.Plans:
                    items = _commonListItemsRepository.GetListItems<Plans>(tableName);
                    break;

                case LookupTableName.Currencies:
                    items = _commonListItemsRepository.GetListItems<Currencies>(tableName);
                    break;

                case LookupTableName.AppraisalPurposeMazamTypes:

                    items = _commonListItemsRepository.GetListItems<AppraisalPurposeMazamTypes>(tableName);

                    break;
                case LookupTableName.ProcessContactRoleTypes:
                   
                    items = _commonListItemsRepository.GetListItems<ProcessContactRoleTypes>(tableName);
                    break;
                case LookupTableName.SuperContactTypes:

                    items = new[]
                     {
                    new ListItem{ Id =(byte)SuperContactTypesEnum.PersonContact, Name = "פרטי"},
                    new ListItem{ Id =(byte)SuperContactTypesEnum.CompanyContact, Name ="חברה"}
                };
                    break;
                default:
                    throw new ApplicationException($"{ToString()} error:There is no table with name {tableName} ");
            }

            return items;
        }
        

    }
}
