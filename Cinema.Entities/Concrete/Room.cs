using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Room:IEntity //Salon
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool Status { get; set; }
       
        
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
