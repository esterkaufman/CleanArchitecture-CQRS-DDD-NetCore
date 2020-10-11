using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Configuration
{
    public class ApiVersions
    {
        public bool GroupByVersion { get; set; }
        public List<Version> Versions { get; set; }
    }

    public class Version
    {

        public string Name { get; set; }
        public bool Default { get; set; }
    }
}
