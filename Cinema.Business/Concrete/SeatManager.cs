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
    public class SeatManager : ISeatService
    {
        private readonly ISeatDal _setDal;
        public SeatManager(ISeatDal seatDal)
        {
            _setDal = seatDal;
        }
        public async  Task Add(Seat seat)
        {
            await _setDal.Add(seat);
        }

        public async Task AddRange(List<Seat> seatList)
        {
            await _setDal.AddRange(seatList);
        }

        public async Task Delete(int id)
        {
            Seat seat = await _setDal.Get(x=>x.SeatId == id);
            await _setDal.Delete(seat);
        }

        public async Task<Seat> GetSeatById(int id)
        {
            return await _setDal.Get(x=>x.SeatId == id);
        }

        public async Task<IList<Seat>> GetSeatList()
        {
            return await _setDal.GetAll();
        }

        public async Task<IList<Seat>> SeatAllByStatus(bool value)
        {
            return await _setDal.GetAll(x=>x.Status == value);
        }

        public async Task<IList<Seat>> SeatWithRoom()
        {
            return await _setDal.SeatWithRoom();
        }

        public async Task Update(Seat seat)
        {
            await _setDal.Update(seat);
        }
    }
}
