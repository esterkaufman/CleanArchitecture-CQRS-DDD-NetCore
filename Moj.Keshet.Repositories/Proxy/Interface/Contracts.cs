using Moj.Core.Rest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Repositiories.Proxy.Interface
{
    public class ResponseData
    {
        public IList<ReturnData> ReturnsData { get; set; }
    }

    public class ReturnData
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }

}

