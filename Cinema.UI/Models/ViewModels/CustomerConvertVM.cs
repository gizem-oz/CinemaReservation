using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class CustomerConvertVM: ModelBase
    {
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
