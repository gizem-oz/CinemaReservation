using Cinema.Core.DataAccess.EntityFramework;
using Cinema.DataAccess.Abstract;
using Cinema.DataAccess.Concrete.EntityFramework.Context;
using Cinema.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Concrete.EntityFramework
{
    public class ReservationDal:BaseRepository<Reservation>,IReservationDal
    {
        public ReservationDal(CinemaContext context):base(context)
        {

        }
        public async Task<IList<Reservation>> ReservationWitCustAndEmpAsync()
        {
            return await set.Include(x => x.Customer).Include(x => x.Employee).Include(x=>x.Movie).Include(x=>x.Room).Include(x=>x.Seat).ToListAsync();
        }

        public async Task<IList<Reservation>> ReservationCustomerId(Expression<Func<Reservation, bool>> expression)
        {
            return await set.Include(x => x.Customer).Include(x => x.Employee).Include(x => x.Movie).Include(x => x.Room).Include(x => x.Seat).Where(expression).ToListAsync();
        }

        public async Task<Reservation> ReservationIncludeSeat(int reservationId)
        {
            return await set.Include(x => x.Seat).FirstOrDefaultAsync(x => x.Id == reservationId);
        }
    }
}
