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
    public class CostumerOrderRepository : GenericRepository<CostumerOrder>, ICostumerOrderRepository
    {
        public CostumerOrderRepository(ApiContext context) : base(context)
        {

            _context = context;

        }

        private readonly ApiContext _context;

        public IEnumerable<CostumerOrder> GetAllData(int id)
        {
            var CostumerOrders = _context.CostumerOrder.Where(e => e.CostumerId == id).ToList();
            return CostumerOrders;
        }
    }
}
