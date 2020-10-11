using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ApplicationSettings
    {
        public ApplicationSettings()
        {
            ApplicationSettingsDebug = new HashSet<ApplicationSettingsDebug>();
        }

        public int ApplicationSettingsId { get; set; }
        public string SettingDescription { get; set; }
        public string StringValue { get; set; }
        public long? LongValue { get; set; }
        public DateTime? DateValue { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ApplicationSettingsDebug> ApplicationSettingsDebug { get; set; }
    }
}
