using Moj.Keshet.Shared.Enums.DatabaseEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Processes
{
    public class ProcessFlatSearchResult
    {    
        public long EntityId { get; set; }
        public long ProcessId { get; set; }        
        public ProcessTypesEnum ProcessType { get; set; }
        public string ProcessSubTypeName { get; set; }
        public string ProcessStatusName { get; set; }
        public string ProcessStatusToolip { get; set; }
        public DateTime? ProcessDate { get; set; }      
        public string AppraisalPurposeTypeName { get; set; }
        public int AppraiserContactId { get; set; }
        public string AppraiserContactName { get; set; }        
        public string AppraiserContactPhone { get; set; }        
        public string PropertyLocation { get; set; }


        public string ClientFileNumber { get; set; }
        public int Block { get; set; }
        public short FromParcel { get; set; }
        public short ToParcel { get; set; }


    }
}
