using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Seat:IEntity
    {
        public int SeatId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool Status { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
