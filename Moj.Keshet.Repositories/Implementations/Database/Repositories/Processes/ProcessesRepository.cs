using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Domain.Models.Processes;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Repositories.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using Moj.Keshet.Domain.ModelsDB;
using AutoMapper;
using Moj.Keshet.Repositories.Extensions;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository : IProcessesRepository
    {

        public async Task<Process> GetProcessById(long processID)
        {
            var process = await _db.Processes.Include(c => c.ProcessesToContactsConnections)
                .Include(p => p.Requests)
                .Include(p => p.ProcessProperties)
               .Include("ProcessProperties.PropertyIdentities")
                .FirstOrDefaultAsync(x => x.ProcessID == processID);
            process.DistrictAppealOrganizationContact = new Companies() { ContactId = process.DistrictAppealOrganizationContactID.Value };
            var interestContactConnections = process.ProcessesToContactsConnections.Where(x =>
               x.ProcessToContactConnectionTypeID == (byte)ProcessToContactConnectionTypesEnum.InterestContact).ToArray();
           
            var groups = interestContactConnections.GroupBy(row => row.ContactID);
            var interestContacts = new List<Contact>();
            foreach (var group in groups)
            {
                var contact = new Contact
                {
                    ContactID = group.Key,
                    ProcessContactRoleTypes = @group.Select(x => x.ProcessContactRoleTypeID.HasValue ? new ListItem { Id = x.ProcessContactRoleTypeID.Value } : null).ToArray()
                };
                interestContacts.Add(contact);
            }

            // process.InterestContacts = interestContacts.ToArray();

            var x = _mapper.Map<Process>(process);
            x.InterestContacts = interestContacts.ToArray();
            return x;
        }


        public async Task<ProcessFlatSearchResult[]> SearchAsync(ProcessSearchCriteria searchCriteria, bool isBO)
        {        
            var processesToSearch = _db.Set<Processes>().AsQueryable();
            AddProcessSearchConditions(ref processesToSearch, searchCriteria);
            var dbResults = await processesToSearch.OrderByDescending(x => x.ProcessID).ToListAsync();
            var list = dbResults.Select(e => _mapper.Map<Processes, ProcessFlatSearchResult>(e, opt => opt.AfterMap((src, dest) =>
            {

            }))).ToArray();
            return list;
        }

        #region Join tables

        private string[] GetSearchIncludeEntities()
        {
            ///TODO convert Includes to Join
            return new string[]
            {
                ExpressionHelper.GetPropertyName<Processes>(x => x.ProcessType),
                ExpressionHelper.GetPropertyName<Processes>(x => x.HandlingDistrict),
                ExpressionHelper.GetPropertyName<Processes>(x => x.AppealOrganization),
                ExpressionHelper.GetPropertyName<Processes>(x => x.Requests),
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Requests)}.{ExpressionHelper.GetPropertyName<Requests>(x => x.RequestType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Requests)}.{ExpressionHelper.GetPropertyName<Requests>(x => x.RequestHistory)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Requests)}.{ExpressionHelper.GetPropertyName<Requests>(x => x.RequestStatusType)}",
                  ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures),
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures)}.{ExpressionHelper.GetPropertyName<Procedures>(x => x.ProcedureType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures)}.{ExpressionHelper.GetPropertyName<Procedures>(x => x.ProcedureHistory)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures)}.{ExpressionHelper.GetPropertyName<Procedures>(x => x.ProcedureStatusType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures)}.{ExpressionHelper.GetPropertyName<Procedures>(x => x.LastProcedureAction)}",
                ExpressionHelper.GetPropertyName<Processes>(x => x.DistrictAppealOrganizationContact),
                ExpressionHelper.GetPropertyName<Processes>(x => x.FileToProcessesConnections),
                ExpressionHelper.GetPropertyName<Processes>(x => x.AppraisalBusinessNeedType),
                ExpressionHelper.GetPropertyName<Processes>(x => x.ProcessProperties),
                ExpressionHelper.GetPropertyName<Processes>(x => x.ProcessesToContactsConnections),
                //$"{ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures)}.{ExpressionHelper.GetPropertyName<Procedures>(x => x.ProcedureHistory)}.{ExpressionHelper.GetPropertyName<ProcedureHistory>(x => x.ProcedureActionType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Procedures)}.{ExpressionHelper.GetPropertyName<Procedures>(x => x.ProcedureHistory)}.{ExpressionHelper.GetPropertyName<ProcedureHistory>(x => x.ProcedureStatusType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Requests)}.{ExpressionHelper.GetPropertyName<Requests>(x => x.RequestHistory)}.{ExpressionHelper.GetPropertyName<RequestHistory>(x => x.RequestStatusType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Requests)}.{ExpressionHelper.GetPropertyName<Requests>(x => x.RequestHistory)}.{ExpressionHelper.GetPropertyName<RequestHistory>(x => x.AppraiserType)}",
                $"{ExpressionHelper.GetPropertyName<Processes>(x => x.Requests)}.{ExpressionHelper.GetPropertyName<Requests>(x => x.RequestHistory)}.{ExpressionHelper.GetPropertyName<RequestHistory>(x => x.RequestStatusReasonType)}",
            };
        }
        private IQueryable<TEntity> Include<TEntity>(IQueryable<TEntity> source, string[] entityNames) where TEntity : class
        {
            if (source != null && entityNames.Length > 0)
            {
                var result = source;
                foreach (var entityName in entityNames)
                {
                    result = result.Include(entityName);
                }

                return result;
            }
            return null;
        }

        #endregion

        private void AddProcessSearchConditions(ref IQueryable<Processes> processesToSearch, ProcessSearchCriteria searchCriteria)
        {
            processesToSearch = Include(processesToSearch.AsNoTracking(), GetSearchIncludeEntities());

            AddProcessTypesCondition(ref processesToSearch, searchCriteria.ProcessType);
            AddHandledByCondition(ref processesToSearch, searchCriteria.HandledBy);
            AddProcessIdCondition(ref processesToSearch, searchCriteria.ProcessType, searchCriteria.ProcessID);
            if (searchCriteria.ProcessSubTypeIDs != null)
                AddProcessSubTypesCondition(ref processesToSearch, searchCriteria.ProcessType, searchCriteria.ProcessSubTypeIDs.ToList());
            //if (searchCriteria.ProcessStatusIDs != null)
                //AddProcessStatusCondition(ref processesToSearch, searchCriteria.ProcessType, searchCriteria.ProcessStatusIDs.ToList());
            AddAppealOrganizationCondition(ref processesToSearch, searchCriteria.AppealOrganizationIDs);
            AddDistrictAppealOrganizationContactCondition(ref processesToSearch, searchCriteria.DistrictAppealOrganizationContactId);
            AddProcessDateCondition(ref processesToSearch, searchCriteria.FromDate, searchCriteria.ToDate);
            AddProcessClientOrderNumberCondition(ref processesToSearch, searchCriteria.ProcessClientOrderNumber);
            AddProcessClientFileNumberCondition(ref processesToSearch, searchCriteria.ProcessClientFileNumber);
            AddHouseNumberCondition(ref processesToSearch, searchCriteria.HouseNumber);
            AddParcelCondition(ref processesToSearch, searchCriteria.FromParcelNumber, searchCriteria.ToParcelNumber);
            AddBlockCondition(ref processesToSearch, searchCriteria.BlockNumber);
            AddPropertyGrossAreaCondition(ref processesToSearch, searchCriteria.PropertyGrossAreaFrom, searchCriteria.PropertyGrossAreaTo);
            
            AddPlanCondition(ref processesToSearch, searchCriteria.PlanCode);
            AddPlotCondition(ref processesToSearch, searchCriteria.FromPlot, searchCriteria.ToPlot);
            AddHandlingDistrictCondition(ref processesToSearch, searchCriteria.HandlingDistrictId);
            AddCityCondition(ref processesToSearch, searchCriteria.Cities);
            AddStreetCondition(ref processesToSearch, searchCriteria.Street);
            AddProcessAppraisalDateToAssignCondition(ref processesToSearch, searchCriteria.AppraisalDateToAssignFrom, searchCriteria.AppraisalDateToAssignTo);
            AddProcessAppraiserFeesCondition(ref processesToSearch, searchCriteria.AppraiserFeesFrom, searchCriteria.AppraiserFeesTo);
           
            AddAppraiserContactCondition(ref processesToSearch, searchCriteria.ProcessAppraiserContactId);
            AddInterestContactIDsCondition(ref processesToSearch, searchCriteria.InterestContactIDs);
            AddAppraiserContactIDsCondition(ref processesToSearch, searchCriteria.AppraiserContactIDs);

            AddFileIdCondition(ref processesToSearch, searchCriteria.FileId);
            AddExcludeProcessStatusTypeCondition(ref processesToSearch, searchCriteria.ProcessType, searchCriteria.ExcludeProcessStatusType);
            AddCloseDateCondition(ref processesToSearch, searchCriteria.FromCloseDate, searchCriteria.ToCloseDate);
            if (searchCriteria.ContactSubTypeIDs != null)
                AddContactSubTypesCondition(ref processesToSearch, searchCriteria.ContactSubTypeIDs.ToList());
            
            AddPartialProcedureCondition(ref processesToSearch, searchCriteria.ProcessType, searchCriteria.IsPartialProcedure);
            AddclientFileNumberIsraelLandAuthority(ref processesToSearch, searchCriteria.ClientFileNumberIsraelLandAuthority);
            if (searchCriteria.PrototypeIDs != null)
                AddPrototypesCondition(ref processesToSearch, searchCriteria.PrototypeIDs.ToList());
        }

        #region Conditions

        private void AddProcessTypesCondition(ref IQueryable<Processes> processesToSearch, ProcessTypesEnum processType)
        {
            processesToSearch = processesToSearch.Where(p => p.ProcessTypeId == (byte)processType);
        }

        private void AddPartialProcedureCondition(ref IQueryable<Processes> processesToSearch, ProcessTypesEnum processType, bool? isPartialProcedure)
        {
            if (isPartialProcedure.HasValue && isPartialProcedure.Value && processType == ProcessTypesEnum.Procedure)
                processesToSearch = processesToSearch.Where(p => p.Procedures != null && p.EntityRelatedID == null);
        }

        private void AddProcessIdCondition(ref IQueryable<Processes> processesToSearch, ProcessTypesEnum processType, long? processesId)
        {
            if (processesId.HasValue)
                processesToSearch = processType == ProcessTypesEnum.Request ? processesToSearch.Where(r => processesId == r.Requests.RequestId) : processesToSearch.Where(r => processesId == r.Procedures.ProcedureId);
        }

        private void AddProcessSubTypesCondition(ref IQueryable<Processes> processesToSearch, ProcessTypesEnum processType, IList<byte> ProcessSubTypeIDs)
        {
            if (ProcessSubTypeIDs.Any())
            {
                processesToSearch = processType == ProcessTypesEnum.Request
                    ? processesToSearch.Where(r => ProcessSubTypeIDs.Any(rt => rt == r.Requests.RequestTypeID))
                    : processesToSearch.Where(r => ProcessSubTypeIDs.Any(rt => rt == r.Procedures.ProcedureTypeID));
            }
        }

       
        private void AddExcludeProcessStatusTypeCondition(ref IQueryable<Processes> processesToSearch, ProcessTypesEnum processType, byte? excludeProcessStatusType)
        {
            if (excludeProcessStatusType.HasValue)
            {
                processesToSearch = processType == ProcessTypesEnum.Request
                    ? processesToSearch.Where(p => p.Requests.RequestStatusTypeID != excludeProcessStatusType)
                    : processesToSearch.Where(p => p.Procedures.ProcedureStatusTypeID != excludeProcessStatusType);
            }
        }

        private void AddAppealOrganizationCondition(ref IQueryable<Processes> processesToSearch, IList<byte> appealOrganizationIDs)
        {
            if (appealOrganizationIDs.Any())
                processesToSearch = processesToSearch.Where(p => appealOrganizationIDs.Contains (p.AppealOrganizationID));
        }

        private void AddDistrictAppealOrganizationContactCondition(ref IQueryable<Processes> processesToSearch, int? districtAppealOrganizationContactID)
        {
            if (districtAppealOrganizationContactID.HasValue)
                processesToSearch = processesToSearch.Where(p => districtAppealOrganizationContactID == p.DistrictAppealOrganizationContactID);
        }

        private void AddProcessDateCondition(ref IQueryable<Processes> processesToSearch, DateTime? processDateFrom, DateTime? processDateTo)
        {
            if (processDateFrom.HasValue)
            {
                processDateFrom = new DateTime(processDateFrom.Value.Year, processDateFrom.Value.Month, processDateFrom.Value.Day, 0, 0, 0);
                processesToSearch = processesToSearch.Where(r => r.CreateDate >= processDateFrom.Value);
            }

            if (processDateTo.HasValue)
            {
                processDateTo = new DateTime(processDateTo.Value.Year, processDateTo.Value.Month, processDateTo.Value.Day, 23, 59, 59);
                processesToSearch = processesToSearch.Where(r => r.CreateDate <= processDateTo.Value);
            }
        }

        private void AddProcessClientOrderNumberCondition(ref IQueryable<Processes> processesToSearch, string processClientOrderNumber)
        {
            if (processClientOrderNumber != null)
                processesToSearch = processesToSearch.Where(r => r.ClientOrderNumber == processClientOrderNumber);
        }

        private void AddProcessClientFileNumberCondition(ref IQueryable<Processes> processesToSearch, string requestClientFileNumber)
        {
            if (requestClientFileNumber != null)
                processesToSearch = processesToSearch.Where(r => r.ClientFileNumber == requestClientFileNumber);
        }

        private void AddHouseNumberCondition(ref IQueryable<Processes> processesToSearch, string houseNumber)
        {
            if (houseNumber != null)
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.HouseNumber == houseNumber));
        }

        private void AddParcelCondition(ref IQueryable<Processes> processesToSearch, int? fromParcelNumber, int? toParcelNumber)
        {
            if (fromParcelNumber.HasValue)
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.FromParcelNumber >= fromParcelNumber)));
            if (toParcelNumber.HasValue)
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.ToParcelNumber <= toParcelNumber)));
        }

        private void AddPropertyGrossAreaCondition(ref IQueryable<Processes> processesToSearch, decimal? propertyGrossAreaFrom, decimal? propertyGrossAreaTo)
        {
            if (propertyGrossAreaFrom.HasValue)
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.GrossArea >= propertyGrossAreaFrom)));
            if (propertyGrossAreaTo.HasValue)
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.GrossArea <= propertyGrossAreaTo)));
        }

        private void AddBlockCondition(ref IQueryable<Processes> processesToSearch, int? blockNumber)
        {
            if (blockNumber.HasValue)
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.BlockNumber == blockNumber)));
        }

        private void AddPlotCondition(ref IQueryable<Processes> requestsToSearch, string fromPlot, string toPlot)
        {
            bool hasOnlyNumbers = (string.IsNullOrEmpty(fromPlot) || fromPlot.All(Char.IsDigit))
                                  && (string.IsNullOrEmpty(toPlot) || toPlot.All(Char.IsDigit));
            if (hasOnlyNumbers)
            {
                if (!string.IsNullOrEmpty(fromPlot))
                {
                    int fromPlotNumber = Convert.ToInt32(fromPlot);
                    requestsToSearch = requestsToSearch.Where(
                        r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.FromPlotNumber >= fromPlotNumber)));
                }

                if (!string.IsNullOrEmpty(toPlot))
                {
                    int toPlotNumber = Convert.ToInt32(toPlot);
                    requestsToSearch = requestsToSearch.Where(
                        r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.ToPlotNumber <= toPlotNumber)));
                }
            }
            else

            {
                if (!string.IsNullOrEmpty(fromPlot))
                    requestsToSearch = requestsToSearch.Where(
                        r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.FromPlot.Equals(fromPlot))));

                if (!string.IsNullOrEmpty(toPlot))
                    requestsToSearch = requestsToSearch.Where(
                        r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.ToPlot.Equals(toPlot))));
            }
        }

        private void AddHandledByCondition(ref IQueryable<Processes> processesToSearch, string handledBy)
        {
            if (!string.IsNullOrEmpty(handledBy))
                processesToSearch = processesToSearch.Where(f => f.CreatedBy.ToLower() == handledBy.ToLower());
        }

        private void AddHandlingDistrictCondition(ref IQueryable<Processes> processesToSearch, int? handlingDistrictId)
        {
            if (handlingDistrictId.HasValue)
                processesToSearch = processesToSearch.Where(f => f.HandlingDistrictID == handlingDistrictId);
        }

        private void AddPlanCondition(ref IQueryable<Processes> processesToSearch, string planCode)
        {
            if (!string.IsNullOrEmpty(planCode))
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessProperties.Any(x => x.PropertyIdentities.Any(p => p.PlanCode.Contains(planCode))));
        }

        private void AddStreetCondition(ref IQueryable<Processes> processesToSearch, ListItem street)
        {
            if (street != null)
            {
                if (street.Id != 0)
                    processesToSearch = processesToSearch.Where(x => x.ProcessProperties.Any(ca => ca.CityID == street.Id));
                else
                    processesToSearch = processesToSearch.Where(x => x.ProcessProperties.Any(ca => ca.StreetNameNotVerified == street.Name));
            }
        }

        private void AddCityCondition(ref IQueryable<Processes> processesToSearch, IList<ListItem> cities)
        {
            if (cities.Count() == 1)
            {
                var city = cities.First();
                if (city != null)
                {
                    processesToSearch = city.Id != 0 ? processesToSearch.Where(x => x.ProcessProperties.Any(ca => ca.CityID == city.Id)) : processesToSearch.Where(x => x.ProcessProperties.Any(ca => ca.CityNameNotVerified == city.Name));
                }
            }
            if (cities.Count() > 1)
            {

                var citiesNames = cities.Select(x => x.Name).ToArray();
                processesToSearch = processesToSearch.Where(
                    x => x.ProcessProperties.Any(
                        pp => citiesNames.Contains(pp.CityNameNotVerified)));

            }

        }

        private void AddProcessAppraisalDateToAssignCondition(ref IQueryable<Processes> processesToSearch, DateTime? appraisalDateToAssignFrom, DateTime? appraisalDateToAssignTo)
        {
            if (appraisalDateToAssignFrom.HasValue)
                processesToSearch = processesToSearch.Where(r => r.ProcessAppraisalPurposes.Any(x => x.AppraisalDateToAssign >= appraisalDateToAssignFrom));
            if (appraisalDateToAssignTo.HasValue)
                processesToSearch = processesToSearch.Where(r => r.ProcessAppraisalPurposes.Any(x => x.AppraisalDateToAssign <= appraisalDateToAssignTo));
        }

        private void AddProcessAppraiserFeesCondition(ref IQueryable<Processes> processesToSearch, decimal? appraiserFeesFrom, decimal? appraiserFeesTo)
        {
            if (appraiserFeesFrom.HasValue)
                processesToSearch = processesToSearch.Where(r => r.AppraiserFees >= appraiserFeesFrom);
            if (appraiserFeesTo.HasValue)
                processesToSearch = processesToSearch.Where(r => r.AppraiserFees <= appraiserFeesTo);
        }        

        
        private void AddAppraiserContactCondition(ref IQueryable<Processes> processesToSearch, int? appraiserContactID)
        {
            if (appraiserContactID.HasValue)
            {
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessesToContactsConnections.Any(ptc =>
                        ptc.ContactID == appraiserContactID && ptc.ProcessToContactConnectionTypeID == (byte)ProcessToContactConnectionTypesEnum.Appraiser));
            }
        }

        private void AddAppraiserContactIDsCondition(ref IQueryable<Processes> processesToSearch, int[] appraiserContactIDs)
        {
            if (appraiserContactIDs != null && appraiserContactIDs.Any())
            {
                var connectionType = (byte)ProcessToContactConnectionTypesEnum.Appraiser; //to prevent casting in SQL
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessesToContactsConnections.Any(ptc =>
                        appraiserContactIDs.Contains(ptc.ContactID) && ptc.ProcessToContactConnectionTypeID == connectionType));
            }
        }

        private void AddInterestContactIDsCondition(ref IQueryable<Processes> processesToSearch, int[] interestContactIDs)
        {
            if (interestContactIDs != null && interestContactIDs.Any())
            {
                var connectionType = (byte)ProcessToContactConnectionTypesEnum.InterestContact; //to prevent casting in SQL
                processesToSearch = processesToSearch.Where(
                    r => r.ProcessesToContactsConnections.Any(ptc =>
                        interestContactIDs.Contains(ptc.ContactID) && ptc.ProcessToContactConnectionTypeID == connectionType));
            }
        }

       
        private void AddContactSubTypesCondition(ref IQueryable<Processes> processesToSearch, IList<byte> contactSubTypesIDs)
        {
            if (contactSubTypesIDs.Any())
                processesToSearch = processesToSearch.Where(p => contactSubTypesIDs.Any(cType => cType == p.AppraiserTypeID));
        }

        
        private void AddCloseDateCondition(ref IQueryable<Processes> processesToSearch, DateTime? fromCloseDate, DateTime? toCloseDate)
        {
            if (fromCloseDate.HasValue)
            {
                fromCloseDate = new DateTime(fromCloseDate.Value.Year, fromCloseDate.Value.Month, fromCloseDate.Value.Day, 0, 0, 0);
                processesToSearch = processesToSearch.Where(r =>
                    r.Procedures != null && r.Procedures.ProcedureHistory.Any(h => h.ProcedureStatusTypeID == (byte)ProcedureStatusTypesEnum.Closed && h.CreateDate >= fromCloseDate.Value));
            }

            if (toCloseDate.HasValue)
            {
                toCloseDate = new DateTime(toCloseDate.Value.Year, toCloseDate.Value.Month, toCloseDate.Value.Day, 23, 59, 59);
                processesToSearch = processesToSearch.Where(r =>
                    r.Procedures != null && r.Procedures.ProcedureHistory.Any(h => h.ProcedureStatusTypeID == (byte)ProcedureStatusTypesEnum.Closed && h.CreateDate <= toCloseDate.Value));
            }
        }

        private void AddFileIdCondition(ref IQueryable<Processes> processesToSearch, long? fileId)
        {
            if (fileId.HasValue)
                processesToSearch = processesToSearch.Where(r => r.FileToProcessesConnections.Any(c => c.FileID == fileId));
        }

        private void AddclientFileNumberIsraelLandAuthority(ref IQueryable<Processes> processesToSearch, string clientFileNumberIsraelLandAuthorityToSearch)
        {
            if (!string.IsNullOrEmpty(clientFileNumberIsraelLandAuthorityToSearch))
            {
                processesToSearch = processesToSearch.Where(x => x.ProcessProperties.Any(y => y.PropertyIdentities.Any(z => z.ClientFileNumberIsraelLandAuthority == clientFileNumberIsraelLandAuthorityToSearch)));
            }
        }
        private void AddPrototypesCondition(ref IQueryable<Processes> processesToSearch, List<byte> prototypeIDs)
        {
            if (prototypeIDs.Any())
            {
                processesToSearch = processesToSearch.Where(f => f.FileToProcessesConnections.FirstOrDefault(c => c.IsMainProcess.HasValue && c.IsMainProcess.Value).Process
                .ProcessAppraisalPurposes.Any(alt => alt.ProtoTypeId.HasValue && prototypeIDs.Contains(alt.ProtoTypeId.Value)));
            }
        }
       

        #endregion Conditions

     

    }
}
