using Cinema.Core.DataAccess;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Abstract
{
    public interface ITicketDal:IRepository<Ticket>
    {
        Task<IList<Ticket>> TicketWithSessionAndReservationAsync();
    }
}
