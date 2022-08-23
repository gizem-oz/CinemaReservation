using Cinema.Business.Abstract;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class TicketManager:ITicketService
    {
        private readonly ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public async Task Create(Ticket ticket)
        {
            ticket.Status = false;
            await _ticketDal.Add(ticket);
        }

        public async Task AddRangeTicket(List<Ticket> ticket)
        {
            await _ticketDal.AddRange(ticket);
        }

        public async Task Delete(int id)
        {
            Ticket ticket = await GetTicketById(id);
            if (ticket != null)
            {
                ticket.Status = false;
                await Update(ticket);
            }
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _ticketDal.Get(x=>x.Id == id);
        }

        public async Task<IList<Ticket>> TicketList()
        {
             return await _ticketDal.GetAll();
        }

        public async Task Update(Ticket ticket)
        {
            await _ticketDal.Update(ticket);
        }

        public async Task<IList<Ticket>> TicketWithSessionAndReservationAsync()
        {
            return await _ticketDal.TicketWithSessionAndReservationAsync();
        }
        public async Task<IList<Ticket>> TicketBySessionId(int id)
        {
            return await _ticketDal.GetAll(x => x.SessionId == id);
        }
        
    }
}
