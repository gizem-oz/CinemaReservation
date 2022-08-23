using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Dtos
{
    public class ReservationDto:IDto
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public int SeatId { get; set; }
        public DateTime MovieDate { get; set; }
        
    }
}
