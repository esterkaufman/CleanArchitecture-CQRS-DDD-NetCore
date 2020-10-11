using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Moj.Core.Rest.Common.Logging;

namespace Moj.Keshet.Services.MetiatR_LogAndValidate
{
    public class TracingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public TracingBehavior(ILogger logger)
        {
            _logger = logger;
        }
       public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            
            DateTime dtStart = DateTime.Now;
            _logger.Trace($"Before Start {typeof(TRequest).Name} at {dtStart.ToString()}");
            var response = await next();
            _logger.TracePerformance($"After end at {DateTime.Now.ToString()}", (DateTime.Now - dtStart).Milliseconds,dtStart,DateTime.Now);

            return response;
        }
    }

   

}
