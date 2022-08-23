using Cinema.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Adress).NotEmpty();
            RuleFor(x => x.Adress).Length(1,60);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(25);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).Length(2,25);
            RuleFor(x => x.PhoneNumber).Length(11,11);
        }
    }
}
