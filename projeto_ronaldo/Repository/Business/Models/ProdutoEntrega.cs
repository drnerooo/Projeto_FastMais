using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProdutoEntrega
    {
        public ProdutoEntrega(int id, int quantidade)
        {
            this.id = id;
            this.quantidade = quantidade;
        }
        public ProdutoEntrega()
        {
            produtos = new List<Produto>();
            entregas = new List<Entrega>();
        }
        public required int id { get; set; }
        public virtual List<Produto> produtos { get; set; }
        public virtual List<Entrega> entregas { get; set; }        
        public  int quantidade { get; set; }
    }
}
