using Cinema.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.ValidationRules.FluentValidation
{
    public class TicketValidator:AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
