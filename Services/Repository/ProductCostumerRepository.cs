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

        public async Task<ProductCostumer> ObtainPurchasePrice(int productId, int costumerId)
        {

            ProductCostumer productcostumer = _context.ProductCostumer
            .FirstOrDefault(atb => atb.ProductId == productId && atb.CostumerId == costumerId);

            return productcostumer;
        }

    }
}

