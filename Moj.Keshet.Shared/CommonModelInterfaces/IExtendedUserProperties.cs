using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Shared.CommonModelInterface
{
    public interface IExtendedUserProperties : IBaseControlProperties
    {
        string CreatedBy { get; set; }
        DateTime CreateDate { get; set; }

    }
}
