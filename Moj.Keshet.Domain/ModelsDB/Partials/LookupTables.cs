using Moj.Keshet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Blocks : IListItem
    {
        public int Id { get { return BlockId; } }

        public string Name { get { return BlockNumber.ToString(); } }
        public int ParentId { get { return 0; } }
    }

    public partial class Plans : IListItem
    {
        public int Id { get { return PlanId; } }

        public string Name { get { return PlanCode; } }
        public int ParentId { get { return 0; } }
    }

    public partial class Currencies : IListItem
    {
        public int Id { get { return CurrencyCodeID; } }

        public string Name { get { return CurrencyName; } }
        public int ParentId { get { return 0; } }
    }
    public partial class AppraisalPurposeMazamTypes : IListItem
    {
        public int Id { get { return (int)AppraisalPurposeMazamTypeID; } }

        public string Name { get { return AppraisalPurposeMazamTypeName; } }
        public int ParentId { get { return 0; } }
    }
    public partial class ProcessContactRoleTypes:IListItem
    {
        public int Id { get { return this.ProcessContactRoleTypeID; } }

        public string Name { get { return this.ProcessContactRoleTypeName; } }
        public int ParentId { get { return ContactTypeID; } }
    }

    public partial class ContactSubTypes : IListItem
    {
        public int Id { get { return this.ContactSubTypeID; } }

        public string Name { get { return this.ContactSubTypeName; } }
        public int ParentId { get { return ContactTypeID; } }
    }
    public partial class RequestTypes : IListItem
    {
        public int Id { get { return this.RequestTypeID; } }

        public string Name { get { return this.RequestTypeName; } }
        public int ParentId { get { return 0; } }
    }
    
    public partial class RequestActionTypes : IListItem
    {
        public int Id { get { return this.RequestActionTypeID; } }
        public string Name { get { return this.RequestActionTypeName; } }
        public int ParentId { get { return 0; } }
    }


}
