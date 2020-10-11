using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moj.Keshet.Domain.ModelsDB;
using Moj.Keshet.Services.DTOs.Contacts;
using Moj.Keshet.Services.DTOs.ListItems;
using Moj.Keshet.Services.DTOs.Processes;
using Moj.Keshet.Shared.Enums;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Moj.Keshet.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region common
            CreateMap<Domain.Models.BaseModels.BaseEditableModel, DTOs.BaseModels.BaseEditableModel>().ReverseMap();
            CreateMap<Domain.Models.BaseModels.ExtendedEditableModel, DTOs.BaseModels.ExtendedEditableModel>().ReverseMap();
          
            #endregion
            #region Processes

            CreateMap<GetProcessSearchQuery, Domain.Models.Processes.ProcessSearchCriteria>()
                .ForMember(x => x.Cities, opt => opt.Ignore())
                .ForMember(x => x.Street, opt => opt.Ignore());
            CreateMap<Domain.Models.Processes.ProcessFlatSearchResult, ProcessFlatSearchResult>();

            CreateMap<Domain.Models.Processes.Request,Request>()
              
                .ReverseMap();

            CreateMap<Domain.Models.Processes.Process, Process>()
             
            
               .ReverseMap();

            CreateMap<Domain.Models.Processes.ProcessProperty, ProcessProperty>().ReverseMap();
            CreateMap<Domain.Models.Processes.PropertyIdentity, PropertyIdentity>().ReverseMap();
            #endregion

            #region Contacts   

            CreateMap<Domain.Models.Contacts.ContactIdentity, DTOs.Contacts.ContactIdentity>().ReverseMap();
            CreateMap<Domain.ModelsDB.ContactIdentites, Domain.Models.Contacts.ContactIdentity>().ReverseMap();


            CreateMap<Domain.Models.Contacts.ContactConnectionInfo, DTOs.Contacts.ContactConnectionInfo>()
               .ReverseMap();
            CreateMap<Domain.Models.Contacts.Person, Person>()
              .ReverseMap();

            CreateMap<Domain.Models.ListItems.AppealOrganizationItem, DTOs.ListItems.AppealOrganizationItem>().ReverseMap();


            CreateMap<Domain.Models.Contacts.Contact, Contact>().IncludeBase<Domain.Models.BaseModels.ExtendedEditableModel,DTOs.BaseModels.ExtendedEditableModel>()
                .ForMember(c => c.Person, opt => opt.MapFrom(cn => cn.Person))
                .ForMember(c => c.ContactConnectionInfo, opt => opt.MapFrom(cn => cn.ContactConnectionInfo))
                .ForMember(c=>c.PrimaryKey,opt=>opt.MapFrom(src=>src.ContactID))
                .ReverseMap();

            CreateMap<Domain.ModelsDB.Companies, Domain.Models.Contacts.Company>().ReverseMap();
          
            CreateMap<Domain.Models.Contacts.Company, Company>().ReverseMap();

            CreateMap<Domain.Models.Contacts.ContactsSearchCriteria, ContactsSearchCriteria>().
                ForMember(x => x.City, opt => opt.Ignore()).ReverseMap();
            
            CreateMap<Domain.Models.Contacts.BaseContactFlatSearchResult, BaseContactFlatSearchResult>().IncludeAllDerived().ReverseMap();
            
            CreateMap<Domain.Models.Contacts.AppraiserFlatSearchResult, AppraiserFlatSearchResult>().ReverseMap();
            CreateMap<Domain.Models.Contacts.InterestContactFlatSearchResult, InterestContactFlatSearchResult>().ReverseMap();
            CreateMap<Domain.Models.Contacts.DistrictAppealOrganizationFlatSearchResult, DistrictAppealOrganizationFlatSearchResult>().ReverseMap();
            CreateMap<Domain.Models.Contacts.ContactPersonFlatSearchResult, ContactPersonFlatSearchResult>().ReverseMap();
            #endregion

            #region ListItem

            CreateMap<Domain.Models.ListItems.ListItem, ListItem>()
               .ReverseMap();

            #endregion


            #region Repositories Profile Mapper

            #region common
            
            #endregion

            #region Processes

            CreateMap<Processes, Domain.Models.Processes.ProcessFlatSearchResult>()
                    .ForMember(x => x.ProcessType, opt => opt.MapFrom(src => Enum.GetName(typeof(ProcessTypesEnum), src.ProcessTypeId)))
                    .ForMember(x => x.ProcessDate, opt => opt.MapFrom(src => src.CreateDate.Date))
                    .ForMember(x => x.EntityId, opt => opt.MapFrom(src => src.ProcessTypeId == (byte)ProcessTypesEnum.Procedure ? src.Procedures.ProcedureId : src.Requests.RequestId))
                    .ForMember(x => x.ProcessSubTypeName, opt => opt.MapFrom(src => GetProcessSubType(src)))
                    .ForMember(x => x.ProcessStatusName, opt => opt.MapFrom(src => src.ProcessTypeId == (byte)ProcessTypesEnum.Request ? src.Requests.RequestStatusType.RequestStatusTypeName : src.Procedures.ProcedureStatusType.ProcedureStatusTypeName))
                    .ForMember(x => x.AppraisalPurposeTypeName, opt => opt.MapFrom(src => src.AppraisalBusinessNeedType.AppraisalBusinessNeedTypeName))
                    .ForMember(x => x.PropertyLocation, opt => opt.MapFrom(src => GetPropertyLocation(src)))
                    .ForMember(x => x.AppraiserContactId, opt => opt.MapFrom(src => GetContactID(src, ProcessToContactConnectionTypesEnum.Appraiser)))
                    .ForMember(x => x.ProcessStatusToolip, opt => opt.MapFrom(src => src.ProcessTypeId == (byte)ProcessTypesEnum.Request ? src.Requests.RequestStatusType.ToolTip : src.Procedures.ProcedureStatusType.ToolTip))
                    .ForMember(x => x.Block, opt => opt.MapFrom(src => 33322))
                    .ForMember(x => x.FromParcel, opt => opt.MapFrom(src => 525))
                    .ForMember(x => x.ToParcel, opt => opt.MapFrom(src => 588)); 

            CreateMap<Domain.Models.Processes.Request, Domain.ModelsDB.Requests>()
               .ForMember(x => x.RequestTypeID, opt => opt.MapFrom(src => src.RequestType.Id))
               .ForMember(x => x.RequestStatusTypeID, opt => opt.MapFrom(src => src.RequestStatusType.Id)).ReverseMap();

            CreateMap<PropertyIdentities, Domain.Models.Processes.PropertyIdentity>()
                .ForMember(x => x.ParcelStatusType, opt => opt.Ignore());

            CreateMap<ProcessProperties, Domain.Models.Processes.ProcessProperty>()
                .ForMember(x => x.City, opt => opt.Ignore())
                .ForMember(x => x.Street, opt => opt.Ignore());


            CreateMap<Domain.Models.Processes.PropertyIdentity, Domain.ModelsDB.PropertyIdentities>()
               .ForMember(x => x.PropertyIdentityParcelStatusType, opt => opt.Ignore());

            CreateMap<Domain.Models.Processes.ProcessProperty , Domain.ModelsDB.ProcessProperties>()
                .ForMember(x => x.CityID, opt => opt.Ignore())
                .ForMember(x => x.StreetID, opt => opt.Ignore());



            CreateMap<Processes, Domain.Models.Processes.Process>()
               .ForMember(s => s.Request, opt => opt.MapFrom(d => d.Requests))
               .ForMember(x=>x.ProcessType,opt=>opt.MapFrom(src=>new Domain.Models.ListItems.ListItem() { Id=src.ProcessTypeId}))
              .ForMember(x => x.AppealOrganization, opt => opt.MapFrom(src => new Domain.Models.ListItems.AppealOrganizationItem() { Id = src.AppealOrganizationID }))
              .ForMember(x=>x.AppraiserContact,opt=>opt.MapFrom(src=>(AppraiserFlatSearchResult)GetContact(src,ProcessToContactConnectionTypesEnum.Appraiser)))
               .ReverseMap();

            #endregion

            #region Contacts   

            CreateMap<Domain.ModelsDB.ContactConnectionInfo, Domain.Models.Contacts.ContactConnectionInfo>()
               .ReverseMap();
            CreateMap<Persons, Domain.Models.Contacts.Person>()

              .ReverseMap();

            CreateMap<Contacts, Domain.Models.BaseModels.ExtendedEditableModel>().ReverseMap();

            CreateMap<Contacts, Domain.Models.Contacts.Contact>().IncludeBase<Contacts, Domain.Models.BaseModels.ExtendedEditableModel>()
                .ForMember(c => c.ContactID, opt => opt.MapFrom(cn => cn.ContactId))
                .ForMember(c => c.Person, opt => opt.MapFrom(cn => cn.Persons))
                .ForMember(c => c.ContactConnectionInfo, opt => opt.MapFrom(cn => cn.ContactConnectionInfo))
                .ForMember(c => c.ContactIdentities, opt => opt.MapFrom(cn => cn.ContactIdentites))
                .ForMember(x => x.PrimaryKey, opt => opt.MapFrom(src => (long)src.ContactId))
                .ForMember(c => c.SuperContactType, opt => opt.MapFrom(src => src.Persons != null ? new Domain.Models.ListItems.ListItem() { Id = (byte)SuperContactTypesEnum.PersonContact }
                : new Domain.Models.ListItems.ListItem() { Id = (byte)SuperContactTypesEnum.CompanyContact }))
                .ReverseMap();

          
            #endregion

            #region ListItem

            #endregion
            #endregion
        }

        #region Repositories Profile Mapper - Processes - Helper methods

        
        private string GetProcessSubType(Processes src)
        {
            var subTypeName = src.ProcessTypeId == (byte)ProcessTypesEnum.Request ? src.Requests.RequestType.RequestTypeName : src.Procedures.ProcedureType.ProcedureTypeName;
            return subTypeName;
        }

        private string GetPropertyLocation(Processes src)
        {
            var property = src.ProcessProperties.FirstOrDefault();
            if (property != null)
            {
                return property.CityNameNotVerified;
            }

            return "";
        }

        private static string GetContactID(Processes src, ProcessToContactConnectionTypesEnum processToContactConnectionType)
        {
            var connection = src.ProcessesToContactsConnections.FirstOrDefault(x => x.ProcessToContactConnectionTypeID == (byte)processToContactConnectionType);
            return connection?.ContactID.ToString();
        }
        private static BaseContactFlatSearchResult GetContact(Processes src, ProcessToContactConnectionTypesEnum processToContactConnectionType)
        {
            var connection = src.ProcessesToContactsConnections.FirstOrDefault(x => x.ProcessToContactConnectionTypeID == (byte)processToContactConnectionType);
            return connection != null
                ? processToContactConnectionType == ProcessToContactConnectionTypesEnum.ContactPerson ? (BaseContactFlatSearchResult)new ContactPersonFlatSearchResult { ContactId = connection.ContactID } :
                (BaseContactFlatSearchResult)new AppraiserFlatSearchResult { ContactId = connection.ContactID }
                : null;
        }

        #endregion


    }

    public static class MapperExtention
    {
        private static IMapper _mapper;

        public static IServiceCollection UseMapper(this IServiceCollection services)
        {
            //var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            //var mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            var sbp = services.BuildServiceProvider();
            _mapper = sbp.GetService<IMapper>();
            return services;
        }

        public static T Map<T>(this object source)
        {
            return _mapper.Map<T>(source);

        }
        public static IList<T> MapList<T>(this IList listSource)
        {
            return _mapper.Map<IList<T>>(listSource);
        }
    }

}
