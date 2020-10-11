using System;
using Moj.Core.Rest.Common.Logging;

namespace Moj.Keshet.Domain.Utils.Tracing
{
    public class ScopePerformanceTracer : IDisposable
    {
        private DateTime _start = DateTime.Now;
        private ILogger _logger;
        private string _name;

        public ScopePerformanceTracer(ILogger logger, string name)
        {
            _logger = logger;
            _name = name;
        }

        public void Dispose()
        {
            if (_logger == null) return;
            try
            {
                var end = DateTime.Now;
                var duration = (long?) ((end - _start).TotalMilliseconds);
                _logger.TracePerformance($"{_name} took {duration}ms", duration, _start, end);
            }
            catch
            {
                //if any problem the ignore tracing
            } 
        }
    }
}
