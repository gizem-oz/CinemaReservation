using Cinema.Core.DataAccess;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Abstract
{
    public interface IReservationDal:IRepository<Reservation>
    {
        Task<Reservation> ReservationIncludeSeat(int reservationId);
        Task<IList<Reservation>> ReservationWitCustAndEmpAsync();
        Task<IList<Reservation>> ReservationCustomerId(Expression<Func<Reservation, bool>> expression = null);
    }
}
