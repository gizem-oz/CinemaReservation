using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface ITicketService
    {
        Task<IList<Ticket>> TicketBySessionId(int id);
        Task<IList<Ticket>> TicketWithSessionAndReservationAsync();
        Task<Ticket> GetTicketById(int id);
        Task<IList<Ticket>> TicketList();
        Task Create(Ticket ticket);
        Task AddRangeTicket(List<Ticket> ticket);
        Task Update(Ticket ticket);
        Task Delete(int id);
    }
}
