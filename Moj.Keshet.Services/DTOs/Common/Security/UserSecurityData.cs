using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Common.Security
{
   
    public class UserSecurityData
    {

        public User User { get; set; }
        
        //public Dictionary<string, int> UserModules { get; set; }
        //public Dictionary<int, string> UserRoles { get; set; }
        //public KeyValuePair<byte, string> District { get; set; }
    }
}
