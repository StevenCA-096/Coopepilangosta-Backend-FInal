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
    public class CostumerContactRepository : GenericRepository<CostumersContact>, ICostumerContactRepository
    {
        public CostumerContactRepository(ApiContext context) : base(context)
        {
        }
    }
}
