using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface IRoomService
    {
        Task<Room> GetRoomById(int id);
        Task<IList<Room>> RoomList();
        Task Add(Room room);
        Task AddRange(List<Room> room);
        Task Update(Room room);
        Task Delete(int id);
    }
}
