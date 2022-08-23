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
    public class SessionManager:ISessionService
    {
        private readonly ISessionDal _sessionDal;
        public SessionManager(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }

        public async Task Add(Session session)
        {
            await _sessionDal.Add(session);
        }

        public async Task AddRange(List<Session> session)
        {
            await _sessionDal.AddRange(session);
        }

        public async Task Delete(int id)
        {
            Session session = await GetSessionById(id);
            if (session!=null)
            {
                session.Status = false;
                await Update(session);
            }
        }

        public async Task<Session> GetSessionById(int id)
        {
            return await _sessionDal.Get(x=>x.Id==id);
        }

        public async Task<IList<Session>> SessionList()
        {
            return await _sessionDal.GetAll(x=>x.Status == true);
        }

        public async Task<IList<Session>> SessionsWithMovieAndRoom()
        {
            return await _sessionDal.SessionsWithMovieAndRoom();
        }

        public async Task Update(Session session)
        {
            await _sessionDal.Update(session);
        }
        
    }
}
