using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Services.Mapping;
using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Repositories.Extensions;
using System.Collections.Generic;
using System;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using Moj.Keshet.Repositiories.Extensions;
using Moj.Keshet.Domain.Models.ListItems;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository : IContactsRepository
    {
        public async Task<Contact> GetContact(int id)
        {

            var contact = await _db.Contacts
                .Include(x => x.Persons)
                .Include(x => x.ContactConnectionInfo)
                .Include(x => x.ContactIdentites)
                .Include(x => x.Companies)
                .FirstOrDefaultAsync(p => p.ContactId == id);

            return _mapper.Map<Contact>(contact);
        }
        private string[] GetIncludes()
        {
            var includes = new List<string>
            {
                ExpressionHelper.GetPropertyName<Domain.Models.Contacts.Contact>(x => x.Person),

                ExpressionHelper.GetPropertyName<Domain.Models.Contacts.Contact>(x => x.ContactConnectionInfo),

                ExpressionHelper.GetPropertyName<Domain.Models.Contacts.Contact>(x => x.Company),


            };
            return includes.ToArray();
        }

        public async Task<Contact> GetContactByIdNumber(string idNumber)
        {
            var contact = await _db.Contacts.Include(c => c.Persons).Include(c => c.ContactConnectionInfo).FirstOrDefaultAsync(x =>
                  x.ContactIdentites.Any(ci =>
                      (ci.ContactIdentityTypeID == (byte)ContactIdentityTypesEnum.PersonIdNumber ||
                      ci.ContactIdentityTypeID == (byte)ContactIdentityTypesEnum.CompanyIdNumber) &&
                      ci.IdentityNumber == idNumber));
            return _mapper.Map<Contact>(contact);


        }
       
     
        public async Task<Company[]> GetCompanies(int appealOrganization)
        {
            var companies = await _db.Companies.Where(x =>
            x.AppealOrganizationID == appealOrganization).OrderBy(x => x.CompanyOfficeHebrewName).ToListAsync();
            return companies.MapList<Company>().ToArray();
        }

        /// <summary>
        /// only by id for now
        /// </summary>
        /// <param name="contactsSearchCriteria"></param>
        /// <returns></returns>
        public async Task<Contact[]> GetContacts(ContactsSearchCriteria contactsSearchCriteria)
        {

            var contacts = await _db.Contacts.Where(x => contactsSearchCriteria.ContactIDs.Any(z=>z==x.ContactId)).ToListAsync();
            return contacts.MapList<Contact>().ToArray();
        }
        public async Task<BaseContactFlatSearchResult[]> GetBaseContactsByTypeAndId(byte contactTypeID, int[] contactIDs)
        {
            BaseContactFlatSearchResult[] res = null;
            var query = _db.Contacts
                .Join(_db.ContactsToContactTypesConnections,
                    c => c.ContactId,
                    ctc => ctc.ContactID,
                    (c, ctc) =>
                    new { Contact = c, ContactsToContactTypesConnections = ctc })
                .Join(_db.ContactConnectionInfo,
                    joinedResult => joinedResult.Contact.ContactId,
                    cci => cci.ContactId,
                    (joinedResult, cci) => 
                    new { joinedResult.Contact, joinedResult.ContactsToContactTypesConnections, ContactConnectionInfo = cci })
                .GroupJoin(_db.Persons,
                    joinedResult => joinedResult.Contact.ContactId,
                    p => p.ContactID,
                    (joinedResult, p) => 
                    new
                    { joinedResult.Contact, joinedResult.ContactsToContactTypesConnections, joinedResult.ContactConnectionInfo, Person = p })
                .SelectMany(x => x.Person.DefaultIfEmpty(), (joinedResult, p) => 
                    new { joinedResult.Contact, joinedResult.ContactsToContactTypesConnections, joinedResult.ContactConnectionInfo, Person = p })
                .Where(x =>
                    contactIDs.Contains(x.Contact.ContactId) && x.ContactsToContactTypesConnections.ContactTypeID == contactTypeID);

            res = await query.Select(x => new BaseContactFlatSearchResult
            {
                ContactId = x.Contact.ContactId,
                ContactType = x.ContactsToContactTypesConnections.ContactTypeID,
                ContactName = x.Person != null ? $"{x.Person.FirstName} {x.Person.LastName}" : $"",

                Email = x.ContactConnectionInfo.ContactEmail,
                Fax = x.ContactConnectionInfo.ContactFax,
                Telephones = $"{x.ContactConnectionInfo.ContactMobile},{x.ContactConnectionInfo.ContactPhone}",

            }).ToArrayAsync();
            return res;
        }

        public async Task<BaseContactFlatSearchResult[]> ContactsQuery(ContactsSearchCriteria contactsSearchCriteria)
        {
            var contactType = (ContactTypesEnum)contactsSearchCriteria.ContactTypeID;

            BaseContactFlatSearchResult[] res = null;
            var query = _db.Contacts.Join(_db.ContactsToContactTypesConnections.Include(x => x.ContactSubType),
                                                  c => c.ContactId,
                                                  ctc => ctc.ContactID,
                                                  (c, ctc) => new { c, ctc })
                                          .Join(_db.ContactsToContactTypesConnectionsStatusTypes,
                                                 r => r.ctc.ContactsToContactTypesConnectionsStatusTypeID,
                                                  ccst => ccst.ContactsToContactTypesConnectionsStatusTypeID,
                                                  (r, ccst) => new { r.c, r.ctc, ccst })
                                           .Join(_db.ContactConnectionInfo,
                                                  r => r.c.ContactId,
                                                  cci => cci.ContactId,
                                                  (r, cci) => new { r.c, r.ctc, r.ccst, cci })
                                          .GroupJoin(_db.ContactSubTypes,
                                                  r => r.ctc.ContactSubTypeID,
                                                  cst => cst.ContactSubTypeID,
                                                  (r, cst) => new { r.c, r.ctc, r.ccst, r.cci, cst }).
                                                  SelectMany(x => x.cst.DefaultIfEmpty(), (r, x) => new { r.c, r.ctc, r.ccst, r.cci, cst = x })
                                          .GroupJoin(_db.Persons,
                                                  r => r.c.ContactId,
                                                  p => p.ContactID, (r, p) => new { r.c, r.ctc, r.ccst, r.cci, r.cst, p }).
                                                  SelectMany(x => x.p.DefaultIfEmpty(), (r, x) => new { r.c, r.ctc, r.ccst, r.cci, r.cst, p = x })

                                            .GroupJoin(_db.Companies,
                                                  r => r.c.ContactId,
                                                  company => company.ContactId, (r, company) => new { r.c, r.ctc, r.ccst, r.cci, r.cst, r.p, company }).
                                                  SelectMany(x => x.company.DefaultIfEmpty(),
                                                  (r, x) => new
                                                  {
                                                      Contact = r.c,
                                                      ContactsToContactTypesConnections = r.ctc,
                                                      ContactsToContactTypesConnectionsStatusType = r.ccst,
                                                      ContactConnectionInfo = r.cci,
                                                      Person = r.p,
                                                      Company = x
                                                  });

            switch (contactType)
            {
                case ContactTypesEnum.DistrictAppealOrganization:

                    query.LeftOuterJoin(_db.AppealOrganizations, left => left.Company.AppealOrganizationID, right => right.AppealOrganizationID,
                         (left, right) => new
                         {
                             left.Contact,
                             left.ContactsToContactTypesConnections,
                             left.ContactsToContactTypesConnectionsStatusType,
                             left.ContactConnectionInfo,
                             left.Person,
                             left.Company,
                             AppealOrganization = right
                         });

                    break;

                default:
                    break;
            }
            //where
            query.Where(x => x.ContactsToContactTypesConnections.ContactTypeID == (byte)contactType

            && (contactsSearchCriteria.ContactSubTypeIDs.Length==0 ||
              contactsSearchCriteria.ContactSubTypeIDs.Any(z=>z==(byte) x.ContactsToContactTypesConnections.ContactSubTypeID))
            && ( x.ContactsToContactTypesConnections.ContactTypeID == contactsSearchCriteria.ContactTypeID));
           


            //select
            switch (contactType)
            {
                //(ContactId,ContactType,ContactName,ContactsToContactTypesConnectionsStatusTypeName,ContactSubTypeName,telephones, fax, Email	# DynamicFieldNames# )'
                case ContactTypesEnum.ContactPerson:

                    res = await query.Select(x => new ContactPersonFlatSearchResult
                    {
                        ContactId = x.Contact.ContactId,
                        ContactType = x.ContactsToContactTypesConnections.ContactTypeID,
                        ContactName = x.Person != null ? $"{x.Person.FirstName} {x.Person.LastName}" : $"{x.Company.CompanyOfficeHebrewName}",
                        ContactsToContactTypesConnectionsStatusTypeName = x.ContactsToContactTypesConnectionsStatusType.ContactsToContactTypesConnectionsStatusTypeName,
                        ContactSubTypeName = x.ContactsToContactTypesConnections.ContactSubType.Name,
                        Email = x.ContactConnectionInfo.ContactEmail,
                        Fax = x.ContactConnectionInfo.ContactFax,
                        Telephones = $"{x.ContactConnectionInfo.ContactMobile},{x.ContactConnectionInfo.ContactPhone}",
                        Department = x.Person.Department,
                        JobDescription = x.Person.JobDescription,
                        DistrictAppealOrganizationContactsNames = ""//TODO

                    }).ToArrayAsync();


                    break;
                case ContactTypesEnum.Appraiser:
                case ContactTypesEnum.DistrictAppealOrganization:
                case ContactTypesEnum.InterestContact:
                    res = await query.Select(x => new AppraiserFlatSearchResult
                    {
                        ContactId = x.Contact.ContactId,
                        ContactType = x.ContactsToContactTypesConnections.ContactTypeID,
                        ContactName = x.Person != null ? $"{x.Person.FirstName} {x.Person.LastName}" : $"{x.Company.CompanyOfficeHebrewName}",
                        ContactsToContactTypesConnectionsStatusTypeName = x.ContactsToContactTypesConnectionsStatusType.ContactsToContactTypesConnectionsStatusTypeName,
                        //ContactSubTypeName = x.ContactsToContactTypesConnections.ContactSubType.Name,
                        Email = x.ContactConnectionInfo.ContactEmail,
                        Fax = x.ContactConnectionInfo.ContactFax,
                        Telephones = $"{x.ContactConnectionInfo.ContactMobile},{x.ContactConnectionInfo.ContactPhone}",

                    }).ToArrayAsync();

                    break;
                default:
                    break;
            }
            return res;
        }

       
    }




}
