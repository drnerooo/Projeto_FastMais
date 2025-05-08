using Business;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ConferenteRepository : GenericRepository<Conferente>
    {
        public ConferenteRepository(Context context) : base(context)
        {

        }
    }
}
