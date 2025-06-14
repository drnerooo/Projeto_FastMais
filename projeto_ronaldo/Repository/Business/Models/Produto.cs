using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Produto
    {
        public required int id { get; set; }
        public string nome { get; set; }
        public float valor { get; set; }
        public virtual ProdutoEntrega produtoentrega { get; set; }
    }
}
