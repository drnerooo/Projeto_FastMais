using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Repository.Repositories;

namespace Services
{
   public class ConferenteServices : GenericServices<Conferente>
    {
        public ConferenteServices(GenericRepository<Conferente> repository) : base(repository)
        {

        }
    }
}
