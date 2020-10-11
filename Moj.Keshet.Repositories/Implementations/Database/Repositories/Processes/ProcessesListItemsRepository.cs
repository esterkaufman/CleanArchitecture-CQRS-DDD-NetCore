using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Domain.ModelsDB;
using Moj.Keshet.Services.Interfaces.ListItems;
using Moj.Keshet.Shared.Enums;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository : IProcessesListItemsRepository
    {


        #region Processes listItems with special get

        public ListItem[] GetProcessesSpecialListItems(LookupTableName tableName)
        {
            ListItem[] items = null;

            switch (tableName)
            {
                case LookupTableName.RequestTypes:
                    items = GetRequestTypeListItems(tableName);
                    break;

                case LookupTableName.RequestAppraisalTypes:
                    items = GetRequestTypeListItems(tableName, RequestStepsEnum.Appraisal);
                    break;


                case LookupTableName.RequestInspectionTypes:
                    items = GetRequestTypeListItems(tableName, RequestStepsEnum.Inspection);
                    break;

                case LookupTableName.RequestObjectionTypes:
                    items = GetRequestTypeListItems(tableName, RequestStepsEnum.Objection);
                    break;


                default:
                    throw new ApplicationException($"{ToString()} error:There is no table with name {tableName} ");


            }
            return items;
        }

        private ListItem[] GetRequestTypeListItems(LookupTableName tableName, RequestStepsEnum? requestStep = null)
        {

            return GetOrAddInStore<RequestTypes, string>(tableName,
                    (x => requestStep == null ? x.IsActive : x.IsActive && x.RequestStepID == (byte)requestStep),
                    (x => x.RequestTypeName),
                    (x => new ListItem
                    {
                        Id = x.RequestTypeID,
                        Name = x.RequestTypeName,
                        IsActive = x.IsActive
                    }));
        }


        #endregion
    }
}
