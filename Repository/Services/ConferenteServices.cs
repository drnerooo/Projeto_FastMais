using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Repository.EF;
using Repository.Repositories;

namespace Services
{
    public class ConferenteServices : GenericServices<Conferente>
    {
        private readonly Context _context;
        public ConferenteServices(GenericRepository<Conferente> repository, Context context) : base(repository)
        {
            _context = context;
        }
        public Conferente Logar(string login, string senha)
        {
            Conferente conferenteRetorno = null;
            bool valid = true;

            if (login == null || login.Equals(""))
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

        public void CadastrarConferente(Conferente conferente)
        {
            _context.Conferentes.Add(conferente);
            _context.SaveChanges();
        }
        public override bool Insert(Conferente entity)
        {
            bool retorno = true;

            if (entity.nome == null || entity.nome.Equals(""))
            {
                ValidationDictionary.AddError("Nome", "Campo NOME Vazio.");
                retorno = false;
            }
            else if (entity.login == null)
            {
                ValidationDictionary.AddError("Login", "Campo LOGIN Vazio.");
                retorno = false;
            }
            else if (entity.senha == null)
            {
                ValidationDictionary.AddError("Senha", "Campo SENHA Vazio.");
                retorno = false;
            }
            if (retorno)
            {
                retorno = base.Insert(entity);
            }
            return retorno;
        }

            public void DeleteConfirmed(Conferente conferente)
            {
                Repository.Delete(conferente);
            }
       
        
    }
}
