using System;
using System.Collections.Generic;
using System.Text;

namespace  Moj.Keshet.Shared.CommonModelInterface
{
    public interface IBaseControlProperties
    {
        string UpdatedBy { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
