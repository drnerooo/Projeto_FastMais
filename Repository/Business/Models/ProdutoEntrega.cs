using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProdutoEntrega
    {
        public ProdutoEntrega()
        {
        }
        public ProdutoEntrega(int produtoId, int entregaId, int quantidade)
        {
            ProdutoID = produtoId;
            EntregaId = entregaId;
            Quantidade = quantidade;
        }

        public int Id { get; set; }
        public virtual Produto Produto { get; set; }

        public int EntregaId { get; set; }
        public virtual Entrega Entrega { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoID { get; set; }
    }
}
