using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class ReservationVM
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public bool Status { get; set; }
    }
}
