using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Configuration
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public string MyProjectSetting { get; set; }
        public string FakeUser { get; set; }
    }
}
