using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moj.Keshet.Repositiories.Exceptions;
using Moj.Core.Rest.Interfaces;
using Moj.Keshet.Domain.ModelExtensions;
using Moj.Keshet.Domain.ExampleModels;
using Moj.Keshet.Domain.Models.Common;

namespace Moj.Keshet.Repositories.Implementations.Database
{
    public partial class KeshetEntities 
    {
        #region Fields

        private readonly IConnectionStrings _connectionStrings;
        private readonly Moj.Core.Rest.Common.Logging.ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string _defaultUserName = "unknown";

        #endregion Fields

        #region ctor

        public KeshetEntities(IConnectionStrings connectionStrings, ILoggerFactory loggerFactory, Core.Rest.Common.Logging.ILogger logger, IHttpContextAccessor httpContextAccessor)
        {
            _connectionStrings = connectionStrings;
            _logger = logger;
            _loggerFactory = loggerFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion ctor

        #region .Net Core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging(true)
                // Moj.Core.Rest hint: replace MyConnectionStringName by ConnectionString name in your core configurations database
                //.UseSqlServer(_connectionStrings["MyConnectionStringName"]);
                .UseSqlServer(_connectionStrings["Keshet"]);
        }

        #endregion .Net Core

        #region Core

        #region Core Public

        public DbSet<T> GetQuery<T>() where T : class
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //return this.Set<T>().AsNoTracking();
            return this.Set<T>();
        }      

        public void ApplyTransactionTimeout(int seconds)
        {
            Database.SetCommandTimeout(seconds);
        }

        public void SaveNative()
        {
            base.SaveChanges();
        }

        public new Response SaveChanges()
        {
            // https://long2know.com/2016/07/porting-ef6-to-ef7-or-ef-core/

            var objectStateEntries = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            var rootEntry = objectStateEntries.FirstOrDefault();

            UpdateUserProperties(objectStateEntries);

            Validate(objectStateEntries);

            base.SaveChanges();

            return new Response
            {
                Entries = objectStateEntries
            };
        }

        #endregion Core Public

        #region Core Private

        #region Private Methods

        private void Validate(List<EntityEntry> entries)
        {
            var validationErrors = new List<ValidationResult>();


            //var validationErrors = this.ChangeTracker.Entries<IValidatableObject>()
            //var validationErrors = this.ChangeTracker.Entries()
            //.SelectMany(e => e.Entity.Validate(null))
            //.SelectMany(e => Validator.TryValidateObject(e.Entity, )
            //.Where(r => r != ValidationResult.Success)
            //.ToList();

            foreach (var entry in entries)
            {
                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(entry.Entity, new ValidationContext(entry.Entity), results, true))
                {
                    validationErrors.AddRange(results);
                }
            }

            if (validationErrors.Count > 0)
            {
                var messages = validationErrors.Select(x => x.ErrorMessage).ToList<string>();
                var errors = string.Join(",", messages.ToArray());
                _logger.Error($"Pre-save validation errors: {errors}");
                throw new ValidationResultException(messages);
            }
        }

        private void UpdateUserProperties(List<EntityEntry> entries)
        {
            //using (var ts = new Moj.PDO.Shared.Utils.TimeStampTracer("EF Pre-Save Trace Info"))
            {
                var user = GetCurrentUser();
                var dtNow = DateTime.Now;

                foreach (var entry in entries)
                {
                    var traceData = entry.Entity as ITraceData;
                    if (traceData != null)
                    {
                        //Set trace date of base type
                        SetTraceProperties(traceData, entry.State, user, dtNow);
                    }
                }
            }
        }

        private string GetCurrentUser()
        {
            var userName = string.Empty;
            try
            {
                userName = _httpContextAccessor?.HttpContext?.Session?.GetString("UserName") ?? _defaultUserName;
            }
            catch //
            {
                userName = _defaultUserName;
            }
            return userName;
        }

        private static void SetTraceProperties(ITraceData traceData, EntityState stateEntry, string user, DateTime dtNow)
        {
            if (traceData == null)
                return;

            if (stateEntry == EntityState.Added)
            {
                traceData.CreateDate = dtNow;
                traceData.CreateUser = user;
                traceData.UpdateDate = dtNow;
                traceData.UpdateUser = user;
            }
            else
            {
                traceData.UpdateDate = dtNow;
                traceData.UpdateUser = user;
                if (traceData.CreateDate == DateTime.MinValue)
                {
                    traceData.CreateDate = dtNow;
                }
                if (string.IsNullOrEmpty(traceData.CreateUser))
                {
                    traceData.CreateUser = _defaultUserName;
                }
            }
        }

        #endregion Private Methods

        #endregion Core Private

        #endregion Core

        // DbSets

       


    }
}
    