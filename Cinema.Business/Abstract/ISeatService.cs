using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface ISeatService
    {
        Task<IList<Seat>> SeatWithRoom();

        Task<IList<Seat>> SeatAllByStatus(bool value);
        Task<Seat> GetSeatById(int id);
        Task<IList<Seat>> GetSeatList();
        Task Add(Seat seat);
        Task AddRange(List<Seat> seatList);
        Task Update(Seat seat);
        Task Delete(int id);
    }
}
