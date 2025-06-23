using Business.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProdutoServices : GenericServices<Produto>
    {
        public ProdutoServices(GenericRepository<Produto> repository) : base(repository)
        {
        }
    }
}
