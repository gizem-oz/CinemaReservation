using Cinema.Core.DataAccess.EntityFramework;
using Cinema.DataAccess.Abstract;
using Cinema.DataAccess.Concrete.EntityFramework.Context;
using Cinema.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Concrete.EntityFramework
{
    public class SeatDal:BaseRepository<Seat>,ISeatDal
    {
            public SeatDal(CinemaContext context) : base(context)
            {

            }

        public async Task<IList<Seat>> SeatWithRoom()
        {
            return await set.Include(x => x.Room).ToListAsync(); 
        }
    }
}
