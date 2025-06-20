using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Repository.Repositories;

namespace Services
{
    public class ConferenteServices : GenericServices<Conferente>
    {
        public ConferenteServices(GenericRepository<Conferente> repository) : base(repository) { }
        
         public Conferente Logar(string login, string senha)
         {
            Conferente conferenteRetorno = null;
            bool valid = true;

            if (login==null || login.Equals(""))
            {
                ValidationDictionary.AddError("login", "Campo LOGIN Vazio.");
                valid = false;
            }
            else if (senha == null || senha.Equals(""))
            {
                ValidationDictionary.AddError("senha", "Campo SENHA Vazio.");
                valid = false;
            }
            if (valid)
            {
                 conferenteRetorno = Repository.GetAll().Where
                    (x => x.login == login && x.senha == senha).FirstOrDefault();

                if (conferenteRetorno == null)
                {
                    ValidationDictionary.AddError("", "Usuário ou Senha Inválido");
                }
            }
            return conferenteRetorno;
         }          
    }
}
