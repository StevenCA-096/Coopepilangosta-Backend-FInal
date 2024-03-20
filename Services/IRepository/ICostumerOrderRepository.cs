using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface ICostumerOrderRepository : IGenericRepository<CostumerOrder>
    {
        public IEnumerable<CostumerOrder> GetAllData(int id);

    }
}
