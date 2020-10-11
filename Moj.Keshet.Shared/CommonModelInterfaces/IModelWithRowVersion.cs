using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Shared.CommonModelInterface
{
    public interface IModelWithRowVersion
    {
        byte[] RowVersion { get; set; }

        string UpdatedBy { get; set; }
    }

    public interface IModelWithRowVersionEncoded
    {
        string RowVersionString { get; }

        string UpdatedBy { get; set; }
    }
}
