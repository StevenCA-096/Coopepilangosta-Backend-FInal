using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IProductProducerRepository : IGenericRepository<ProductProducer>
    {

        public Task<ProductProducer> ObtainPurchasePrice(int ProductId, int ProducerId);

        public Task<decimal> ObtainPurchasePriceAverage(int ProductId);
    }
}
