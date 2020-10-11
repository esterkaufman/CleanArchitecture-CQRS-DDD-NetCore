using FluentValidation;
using Moj.Keshet.Services.DTOs.Contacts;
using System;

namespace Moj.Keshet.Services.Validation.Contacts
{
    public class ContactDetailsValidator
        : AbstractValidator<Contact>
    {
        public ContactDetailsValidator()
        {


            RuleFor(c => c.ContactID).InclusiveBetween(1, Int32.MaxValue).WithMessage("it must be between 1 and 2314512451");
            //RuleFor(c => c.ContactName).NotEmpty().MaximumLength(20); // Long Star Wars Names


        }
    }
}