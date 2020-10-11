using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Services.Interfaces.ListItems;
using Moj.Keshet.Shared.Enums;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using System.Linq;
using System.Threading.Tasks;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository : IContactsListItemsRepository
    {
        #region Contacts listItems with special get
        public async Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId)
        {
            var res = await _db.ContactToContactConnections
                 .Join(
                 _db.Companies,
                 con => con.ToContactID,
                 comp => comp.ContactId,
                 (con, comp) => new { con, comp.AppealOrganizationID })
                 .Join(_db.AppealOrganizations,
                 r => r.AppealOrganizationID,
                 l => l.AppealOrganizationID,
                 (r, l) => new { r.AppealOrganizationID, r.con })

                 .Where(x => x.con.FromContactID == WorkOrderContactId)

                 .Select(x => new AppealOrganizationItem 
                 { Id = (long)x.AppealOrganizationID, IsIsraelLandAuthority = x.AppealOrganizationID == (byte)AppealOrganizationsEnum.IsraelLandAuthority }).FirstOrDefaultAsync();
            return res;


        }
        #endregion
    }
}
