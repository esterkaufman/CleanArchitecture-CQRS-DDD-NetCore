using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.ListItems
{
    public class ListItem
    {
        public long Id { get; set; }

         public string Name { get; set; }

        public bool IsChecked { get; set; }

        public int ParentId { get; set; }

        public bool IsActive { get; set; }
    }

    public class AppealOrganizationItem : ListItem
    {
        public bool IsIsraelLandAuthority { get; set; }
    }

    public class ListItemToolTip : ListItem
    {
         public string Tooltip { get; set; }
    }
}
