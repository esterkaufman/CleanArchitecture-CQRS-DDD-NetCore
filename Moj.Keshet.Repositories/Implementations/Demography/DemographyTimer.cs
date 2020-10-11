using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Moj.Demography.Rest.Proxy.Interfaces;
using Moj.Core.Rest.Common.Logging;

namespace Moj.Keshet.Repositories.Implementations.Demography
{
    public class DemographyTimer : IHostedService, IDisposable
    {
        //private readonly IDemographyCore _demography;
        private readonly ILogger _logger;
        private readonly IDemographyLoader _loader;

        private Timer _timer;

        #region Ctor

        public DemographyTimer(ILogger logger, /*IDemographyCore demography, */IDemographyLoader loader)
        {
            _logger = logger;
            //_demography = demography;
            _loader = loader;
        }

        #endregion Ctor

        #region IDisposable

        public void Dispose()
        {
            _timer?.Dispose();
        }

        #endregion IDisposable

        #region IHostedService

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _logger.Trace("DemographyRepository timer started");

            //DemographyRepository.LastPerceptionDate = DateTime.MinValue;
            //_loader.LastPerceptionDate = DateTime.MinValue;

            _timer = new Timer(GetLastPerceptionDate, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            //_timer = new Timer(GetLastPerceptionDate, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _logger.Trace("DemographyRepository timer stopped");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        #endregion IHostedService

        private void GetLastPerceptionDate(object state)
        {
            _logger.Trace("DemographyRepository timer running");

            //DemographyRepository.CheckLastPerceptionDate(_logger, _demography);
            _loader.CheckLastPerceptionDate();
        }
    }
}
