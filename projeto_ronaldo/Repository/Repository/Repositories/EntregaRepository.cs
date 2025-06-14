using Business.Models;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EntregaRepository : GenericRepository<Entrega>
    {
        public EntregaRepository (Context context) : base(context)
        {

        }
    }
}
