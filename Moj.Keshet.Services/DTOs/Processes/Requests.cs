using Moj.Keshet.Services.DTOs.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Processes
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
