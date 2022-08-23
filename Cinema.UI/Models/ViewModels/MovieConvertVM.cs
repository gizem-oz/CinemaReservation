using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class MovieConvertVM: ModelBase
    {
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
