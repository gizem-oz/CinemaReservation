using Cinema.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x=>x.LastName).NotEmpty();
            RuleFor(x=>x.LastName).Length(3,25);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).Length(3, 25);
            RuleFor(x => x.PhoneNumber).MaximumLength(11);
            RuleFor(x => x.PhoneNumber).MinimumLength(11);
        }
    }
}
