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
        public Task<ProductCostumer> ObtainPurchasePrice(int ProductId, int CostumerId);
    }
}
