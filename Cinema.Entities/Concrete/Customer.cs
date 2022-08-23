using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Customer:IEntity
    {
        public int AppIdentityUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public virtual AppIdentityUser AppIdentityUser { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
