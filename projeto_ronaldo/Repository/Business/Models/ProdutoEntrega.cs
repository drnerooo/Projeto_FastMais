using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProdutoEntrega
    {
        public required int id { get; set; }
        public virtual List<Produto> produtos { get; set; }
        public virtual List<Entrega> entregas { get; set; }        
        public  int quantidade { get; set; }
    }
}
