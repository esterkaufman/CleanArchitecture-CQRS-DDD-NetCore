
using System;
using System.Collections.Generic;
using System.Text;
using Moj.Keshet.Shared.CommonModelInterface;

namespace Moj.Keshet.Domain.Models.BaseModels
{
    public class ExtendedEditableModel : BaseEditableModel, IExtendedUserProperties
    {
     
        public string CreatedBy { get; set; }
       
        public DateTime CreateDate { get; set; }
    }
}
