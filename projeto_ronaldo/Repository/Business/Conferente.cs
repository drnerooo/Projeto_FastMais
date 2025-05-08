using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Conferente
    {
        public required int id { get; set; }
        public required string nome { get; set; }
        
        public virtual List<Entrega> entregas { get; set; }
    }
}
