using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Entregador
    {
        public int id { get; set; }
        public string nome { get; set; }
        public virtual List<Entrega> entregas { get; set; }
    }
}
