using FluentValidation;
using Moj.Keshet.Services.DTOs.Processes;
using System;
using System.Collections.Generic;

namespace Moj.Keshet.Services.ModelValidators.Processes
{
    public class ProcessesValidator : AbstractValidator<Process>
    {
        public ProcessesValidator()
        {
            RuleFor(c => c.ProcessID).LessThan(99999999).WithMessage("less 99999999");
        }
    }

    /*public class ProcessPropertiesValidator : AbstractValidator<ProcessProperties>
    {
        public ProcessPropertiesValidator()
        {
            RuleFor(c => c.PropertyID).LessThan(99999999).WithMessage("less 99999999");
        }
    }*/

}
