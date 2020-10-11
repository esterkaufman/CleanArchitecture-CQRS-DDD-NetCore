using FluentValidation;
using Moj.Keshet.Services.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.ModelValidators.Contacts
{
    public class ContactsValidator : AbstractValidator<Contact>
    {
        public ContactsValidator()
        {
            RuleFor(c => c.ContactID).LessThan(12468).WithMessage("less 12468");
        }
    }
}
