using Business.Models;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProdutoEntregaRepository : GenericRepository<ProdutoEntrega>
    {
        public ProdutoEntregaRepository(Context context) : base(context)
        {

        }
    }
}
