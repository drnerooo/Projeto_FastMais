using Business;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>
    {
        public ProdutoRepository(Context context) : base(context)
        {

        }
    }
}
