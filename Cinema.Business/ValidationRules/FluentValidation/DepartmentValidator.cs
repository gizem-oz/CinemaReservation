using Cinema.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.ValidationRules.FluentValidation
{
    public class DepartmentValidator:AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(70);
        }
    }
}
