using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Moj.Core.Rest.Common.Logging;

namespace Moj.Keshet.Services.MetiatR_LogAndValidate
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        private readonly ILogger _logger;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators,ILogger logger)
        {
            this.validators = validators;
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                var ex = new ValidationException(failures);
                _logger.ErrorException($"Error in Validate {typeof(TRequest).Name}", ex);
                throw ex;
            }

            return next();
        }
    }
}
