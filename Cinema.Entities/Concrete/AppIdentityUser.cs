using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class AppIdentityUser:IdentityUser<int>
    {
        
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
