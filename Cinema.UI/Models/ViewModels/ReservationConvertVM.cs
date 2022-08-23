using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class ReservationConvertVM: ModelBase
    {

        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int EmployeeId { get; set; }

        public bool Status { get; set; }

        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public int SeatId { get; set; }
        public DateTime MovieDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
