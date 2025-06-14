using Business.Models;
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
        public EntregaServices (GenericRepository<Entrega> repository) : base(repository)
        {
        }
    }
}
