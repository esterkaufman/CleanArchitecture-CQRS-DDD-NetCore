using Moj.Keshet.Shared.Enums;
using Moj.Keshet.Domain.Models.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.Interfaces.ListItems
{
   public  interface IProcessesListItemsRepository:ICommonListItemsRepository
    {
        public ListItem[] GetProcessesSpecialListItems(LookupTableName tableName);
    }
}
