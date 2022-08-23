using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface ISessionService
    {
        Task<IList<Session>> SessionsWithMovieAndRoom();
        Task<Session> GetSessionById(int id);
        Task<IList<Session>> SessionList();
        Task Add(Session session);
        Task AddRange(List<Session> session);
        Task Update(Session session);
        Task Delete(int id);
    }
}
