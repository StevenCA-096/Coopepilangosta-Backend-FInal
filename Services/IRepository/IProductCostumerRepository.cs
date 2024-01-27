using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IProductCostumerRepository : IGenericRepository<ProductCostumer>
    {
        public IEnumerable<ProductCostumer> GetByBothId(int productId, int costumerId);
        public IEnumerable<ProductCostumer> GetAllData(int costumerId);

    }
}
