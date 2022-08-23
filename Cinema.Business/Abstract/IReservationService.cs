using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface IReservationService
    {
        Task<Reservation> ReservationIncludeSeat(int reservationId);
        Task<IList<Reservation>> GetReservation(int customerId);
        Task<IList<Reservation>> ReservationWitCustomerAndEmployeehAsync();
        Task ReservationDelete(int id);
        Task<Reservation> GetReservationById(int id);
        Task<IList<Reservation>> GetAllReservationList();
        Task Add(Reservation reservation);
        Task AddRange(List<Reservation> reservation);
        Task Update(Reservation reservation);
        Task Delete(int id);
    }
}
