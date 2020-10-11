using Moj.Keshet.Shared.CommonModelInterface;
using Moj.Keshet.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moj.Keshet.Domain.Models.BaseModels
{
    public class BaseEditableModel : IPrimaryKeyObject, IModelWithRowVersionEncoded, IStateTrackable, IBaseControlProperties, ICloneable
    {
        
        public long PrimaryKey { get; set; }

      
       
        public string RowVersionString { get; set; }

       
        public string UpdatedBy { get; set; }

        
        public DateTime? UpdateDate { get; set; }

        private ObjectState _modelState;

       
        public ObjectState ModelState
        {
            get
            {
                if (_modelState == 0)
                    _modelState = ObjectState.Unchanged;
                return _modelState;
            }
            set => _modelState = value;
        }

        public static bool IsArrayEmptyNullOrDeleted(BaseEditableModel[] array)
        {
            return array == null || !array.Any() || array.All(x => x.ModelState == ObjectState.Deleted);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
