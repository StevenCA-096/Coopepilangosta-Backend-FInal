using DataAccess.Data;
using DataAccess.Models;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class ProducerOrderRepository : GenericRepository<ProducerOrder>, IProducerOrderRepository
    {
        public ProducerOrderRepository(ApiContext context) : base(context)
        {

        }
    }
}
