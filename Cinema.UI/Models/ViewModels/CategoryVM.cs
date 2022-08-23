using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class CategoryVM
    {
        [Required(ErrorMessage ="Boş Geçilemez!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public bool Status { get; set; }
    }
}
