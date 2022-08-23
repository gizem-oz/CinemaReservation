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
    public class SessionDal:BaseRepository<Session>,ISessionDal
    {
        public SessionDal(CinemaContext context):base(context)
        {

        }

        public async Task<IList<Session>> SessionsWithMovieAndRoom()
        {
            return await set.Include(x => x.Movie).Include(x => x.Room).ToListAsync();
        }
        
    }
}
