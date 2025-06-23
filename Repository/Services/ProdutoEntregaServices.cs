using Business.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProdutoEntregaServices : GenericServices<ProdutoEntrega>
    {
        public ProdutoEntregaServices (GenericRepository<ProdutoEntrega> repository) : base(repository)
        {
        }
    }
}
