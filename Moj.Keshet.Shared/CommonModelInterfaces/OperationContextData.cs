using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moj.Keshet.Shared.CommonModelInterface
{
    
    public class OperationContextData : IOperationContextData
    {
        public UserData UserData { get; set; }
    }
}
