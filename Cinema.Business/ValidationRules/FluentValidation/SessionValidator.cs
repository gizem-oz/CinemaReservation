using Cinema.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.ValidationRules.FluentValidation
{
    public class SessionValidator:AbstractValidator<Session>
    {
        public SessionValidator()
        {
            RuleFor(x => x.ShowDate).NotEmpty();
            RuleFor(x => x.ShowTime).NotEmpty();

        }
    }
}
