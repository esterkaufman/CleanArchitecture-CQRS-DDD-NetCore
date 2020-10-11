using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ApplicationSettingsDebug
    {
        public int ApplicationSettingsDebugID { get; set; }
        public int ApplicationSettingsID { get; set; }
        public string DebugMachine { get; set; }
        public string StringValue { get; set; }
        public long? LongValue { get; set; }
        public DateTime? DateValue { get; set; }

        public virtual ApplicationSettings ApplicationSettings { get; set; }
    }
}
