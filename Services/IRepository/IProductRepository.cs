using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public bool checkProductCode(int codeProduct);
        public bool checkProductStock(int productid, int quantity);

        public IEnumerable<Product> GetStocks();

    }
}
