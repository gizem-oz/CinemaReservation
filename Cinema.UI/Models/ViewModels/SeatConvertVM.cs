using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class SeatConvertVM:ModelBase
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool Status { get; set; }
    }
}
