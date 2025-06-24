using Business.Models;
using Repository.EF;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.Models.Entrega;

namespace Services
{
    public class EntregaServices : GenericServices<Entrega>
    {
        public GenericRepository<EntregaServices> GenericRepository { get; }
        public Context Context { get; }

        public EntregaServices(GenericRepository<Entrega> repo, Context context) : base(repo)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EntregaServices(GenericRepository<Entrega> repository) : base(repository)
        {
        }
        public List<Entrega> GetConcluidasPorEntregador(int id)
        {
            return Repository.GetAll()
                .Where(e => e.id == id && e.Entregue)
                .ToList();
        }

        public List<Entrega> GetPendentes()
        {
            return Repository.GetAll().Where(e => e.status == StatusEntrega.Pendente).ToList();
        }

        public List<Entrega> GetAceitas()
        {
            return Repository.GetAll().Where(e => e.status == StatusEntrega.Aceita).ToList();
        }

        public void AceitarEntrega(int id)
        {
            var entrega = Repository.GetById(id);
            if (entrega != null)
            {
                entrega.status = StatusEntrega.Aceita;
                Repository.Update(entrega);
            }
        }

        public void RecusarEntrega(int id)
        {
            var entrega = Repository.GetById(id);
            if (entrega != null)
            {
                Repository.Delete(entrega);
            }
        }
    }
}
