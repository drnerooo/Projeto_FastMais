using System.Data;

namespace Business.Models
{
    public class Entrega  
    {
        public Entrega(string endereco, float valor, string descricao) 
        {
            this.endereco = endereco;
            this.valor = valor;
            this.descricao = descricao;
            this.conferente = conferente;
            this.entregador = entregador;
        }
        public Entrega(DateTime fim)
        {
            this.inicio = DateTime.Now;
            this.fim = fim;
        }
        public int id { get; set; }
        public string endereco { get; set; }
        public float valor { get; set; }
        public string? descricao { get; set; }
        public DateTime? inicio { get; }
        public DateTime? fim { get; }         
        public virtual Conferente conferente { get; set; }
        public virtual Entregador entregador { get; set; }
        public virtual ProdutoEntrega produtoentrega { get; set; }
    }
}
