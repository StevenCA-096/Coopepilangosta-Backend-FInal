using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class ProductCostumerRepository : GenericRepository<ProductCostumer>, IProductCostumerRepository
    {
        public readonly ApiContext _context;
        public ProductCostumerRepository(ApiContext context) : base(context)

        {
            _context = context;
        }

        public IEnumerable<ProductCostumer> GetByBothId(int productId, int costumerId)
        {

            var productcostumers = _context.ProductCostumer.Where(atb => atb.ProductId == productId && atb.CostumerId == costumerId).ToList();
            return productcostumers;
        }

        public IEnumerable<ProductCostumer> GetAllData(int costumerId)
        {
            var productcostumers = _context.ProductCostumer.Where(e => e.CostumerId == costumerId).ToList();
            return productcostumers;
        }

    }
}

