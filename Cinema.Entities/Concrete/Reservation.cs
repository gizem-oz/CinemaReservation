using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Reservation:IEntity // Rezervasyon
    {
        public Reservation()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public int SeatId { get; set; }
        public DateTime MovieDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Customer Customer {get;set;}
        public virtual Movie Movie { get; set; }
        public virtual Room Room { get; set; }
        public virtual  Seat Seat { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
