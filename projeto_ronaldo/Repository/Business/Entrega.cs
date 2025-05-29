using System.Data;

namespace Business
{
    public class Entrega  
    {   
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
