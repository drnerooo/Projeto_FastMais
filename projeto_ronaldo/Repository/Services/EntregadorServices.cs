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
    }
}
