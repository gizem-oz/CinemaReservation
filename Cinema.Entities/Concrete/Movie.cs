using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Movie:IEntity // Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
