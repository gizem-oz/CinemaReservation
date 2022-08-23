using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Payment:IEntity //Ödeme
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        //Ödeme verileri şu anlık yok
    }
}
