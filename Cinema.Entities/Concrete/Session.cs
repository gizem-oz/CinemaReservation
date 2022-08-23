using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Session:IEntity //Seans
    {
        public int Id { get; set; }
        public int MovieId { get; set; } //FilmId
        public int RoomId { get; set; } //OdaId

        public DateTime ShowDate { get; set; } //GösterimTarihi
        public DateTime ShowTime { get; set; } //GösteriZamanı
        public bool Status { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Room Room { get; set; }
    }
}
