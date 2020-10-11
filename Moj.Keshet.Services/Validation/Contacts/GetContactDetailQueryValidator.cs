using FluentValidation;
using Moj.Keshet.Services.MediatR.Queries.Contacts;
using System;

namespace Moj.Keshet.Services.DTOs.Contacts
{
    public class GetContactDetailQueryValidator
        : AbstractValidator<GetContactQuery>
    {
        public  GetContactDetailQueryValidator()
        {
            const int lessThen = Int32.MaxValue;

            RuleFor(c => c.Id).LessThan(lessThen).WithMessage($"Error! less {lessThen}");


        }
    }
}