using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Moj.Keshet.Domain.ModelExtensions;

namespace Moj.Keshet.Domain.ExampleModels.CodeTables
{
    public class CodeTableRow : IObjectWithChangeTracker, ITraceData//, IObjectStateTracker
    {
        #region CTor

        public CodeTableRow()
        {
            ChangeTracker = new ObjectChangeTracker
            {
                State = TrackedState.Added
            };
        }

        #endregion CTor

        public void Copy(CodeTableRow instance)
        {
            ID = instance.ID;
            Name = instance.Name;
            IsActive = instance.IsActive;
            EnumDescription = instance.EnumDescription;
            CreateUser = instance.CreateUser;
            CreateDate = instance.CreateDate;
            UpdateUser = instance.UpdateUser;
            UpdateDate = instance.UpdateDate;
            ChangeTracker = new ObjectChangeTracker
            {
                State = instance.ChangeTracker.State
            };
        }

        public T CloneSpecial<T>() where T : CodeTableRow, new()
        {
            return new T
            {
                ID = this.ID,
                Name = this.Name,
                IsActive = this.IsActive,
                EnumDescription = this.EnumDescription,
                CreateUser = this.CreateUser,
                CreateDate = this.CreateDate,
                UpdateUser = this.UpdateUser,
                UpdateDate = this.UpdateDate,
                ChangeTracker = new ObjectChangeTracker
                {
                    State = this.ChangeTracker.State
                },
            };
        }

        #region ICloneable

        public object Clone()
        {
            return new CodeTableRow
            {
                ID = this.ID,
                Name = this.Name,
                IsActive = this.IsActive,
                EnumDescription = this.EnumDescription,
                CreateUser = this.CreateUser,
                CreateDate = this.CreateDate,
                UpdateUser = this.UpdateUser,
                UpdateDate = this.UpdateDate,
                ChangeTracker = new ObjectChangeTracker
                {
                    State = this.ChangeTracker.State,
                },
            };
        }

        #endregion

        #region Primitive Properties

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(50)]
        public string EnumDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        [MaxLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        [NotMapped]
        public ObjectChangeTracker ChangeTracker { get; set; }

        #endregion
    }
}
