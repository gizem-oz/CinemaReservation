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
    public class RoomManager:IRoomService
    {
        private readonly IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public async Task Add(Room room)
        {
            var name = await _roomDal.Get(x=>x.Name == room.Name);
            if (name==null)
            {
                await _roomDal.Add(room);
            }
            
        }

        public async Task AddRange(List<Room> room)
        {
            await _roomDal.AddRange(room);
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoomById(id);
            if (room != null)
            {
                room.Status = false;
                await Update(room);
            }
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _roomDal.Get(x=>x.Id == id);
        }

        public async Task<IList<Room>> RoomList()
        {
            return await _roomDal.GetAll(x => x.Status == true);
        }

        public async Task Update(Room room)
        {
            await _roomDal.Update(room);
        }
    }
}
