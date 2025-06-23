using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Produto
    {
        public Produto(string nome, float valor)
        {
            this.nome = nome;
            this.valor = valor;
        }
        public Produto()
        {

        }
        public int id { get; set; }
        public string nome { get; set; }
        public float valor { get; set; }
        public float teste { get; set; }
        public virtual ProdutoEntrega produtoentrega { get; set; }
    }
}
