using Moj.Keshet.Domain.Models.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Processes
{
    public class Request 
    {
        public long RequestId { get; set; }

     
        public ListItem RequestType { get; set; }

      
        public ListItem RequestStatusType { get; set; }

        public DateTime? RequestFillingEndDate { get; set; }

        //Request History
       // public RequestHistory[] RequestHistories { get; set; }
    }
}
