using System.Data;

namespace Business.Models
{
    public class Entrega  
    {
        public Entrega(string endereco, float valor, DateTime inicio, int conferenteID, int entregadorID) 
        {
            this.endereco = endereco;
            this.valor = valor;
            this.descricao = descricao;
            this.conferenteID = conferenteID;
            this.entregadorID = entregadorID;
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
        public DateTime inicio { get; set; }
        public DateTime? fim { get; set; }
        public int conferenteID { get; set; }  
        public int entregadorID { get; set; }
        public virtual Conferente conferente { get; set; }
        public virtual Entregador entregador { get; set; }
        public virtual ProdutoEntrega produtoentrega { get; set; }
    }
}
