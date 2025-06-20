using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repositories;
using Business.Models;
namespace Services
{
    public class EntregadorServices : GenericServices<Entregador>
    {
        public EntregadorServices(GenericRepository<Entregador> repository) : base(repository)
        {

        }
        public Entregador Logar(string login, string senha)
        {
            Entregador entregadorRetorno = null;

            if (login == null || login.Equals(""))
            {
                ValidationDictionary.AddError("login", "Campo LOGIN Vazio.");
            }
            else if (senha == null || senha.Equals(""))
            {
                ValidationDictionary.AddError("senha", "Campo SENHA Vazio.");
            }
            else
            {
                entregadorRetorno = Repository.GetAll().Where
                   (x => x.login == login && x.senha == senha).FirstOrDefault();

                if (entregadorRetorno == null)
                {
                    ValidationDictionary.AddError("", "Usuário ou Senha Inválido");
                }
            }
            return entregadorRetorno;
        }
    }
}
