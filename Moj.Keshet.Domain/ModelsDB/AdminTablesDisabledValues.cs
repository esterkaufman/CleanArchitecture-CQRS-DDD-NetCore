using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AdminTablesDisabledValues
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public string DisabledKeysCsv { get; set; }
    }
}
