using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Entregador
    {   
        public Entregador()
        {

        }
        public Entregador(string nome)
        {
            this.nome = nome;
        }
        public Entregador(string nome, string login, string senha)
        {
            this.nome = nome;
            this.login = login;
            this.senha = senha;
        }
        public  int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public virtual List<Entrega> entrega_conf { get; set; }
        public virtual List<Entrega> entrega_ent { get; set; }
    }
}
