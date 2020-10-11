using Moj.Keshet.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Shared.CommonModelInterface
{
    public interface IStateTrackable
    {
        ObjectState ModelState { get; set; }
    }
}
