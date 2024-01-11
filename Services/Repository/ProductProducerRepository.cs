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
    public class ProductProducerRepository : GenericRepository<ProductProducer>, IProductProducerRepository
    {
        public readonly ApiContext _context;
        public ProductProducerRepository(ApiContext context) : base(context)

        {
            _context = context;
        }

        public async Task<ProductProducer> ObtainPurchasePrice(int productId, int producerId)
        {

            ProductProducer productproducer = _context.ProductProducer
            .FirstOrDefault(atb => atb.ProductId == productId && atb.ProducerId == producerId);

            return productproducer;
        }

        public async Task<decimal> ObtainPurchasePriceAverage(int productId)
        {
            List<ProductProducer> productProducers = await _context.ProductProducer
                .Where(pp => pp.ProductId == productId)
                .ToListAsync(); 
            if (productProducers.Any())
            {
                decimal averagePurchasePrice = (decimal)productProducers.Average(pp => pp.PurchasePrice);
                return averagePurchasePrice;
            }

            return 0;
        }


    }
}

