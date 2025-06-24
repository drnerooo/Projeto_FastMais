using Business.Models;
using Repository.EF;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EntregaServices : GenericServices<Entrega>
    {
        public GenericRepository<EntregaServices> GenericRepository { get; }
        public Context Context { get; }

        public EntregaServices(GenericRepository<Entrega> repo) : base(repo) { }

        public EntregaServices(GenericRepository<EntregaServices> genericRepository, Context context)
        {
            GenericRepository = genericRepository;
            Context = context;
        }

        public List<Entrega> GetPendentes()
        {
            return Repository.GetAll().Where(e => !e.Entregue).ToList();
        }

        public List<Entrega> GetConcluidasPorEntregador(int id)
        {
            return Repository.GetAll()
                .Where(e => e.id == id && e.Entregue)
                .ToList();
        }
    }
}
