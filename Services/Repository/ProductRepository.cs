using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApiContext _context;
        public ProductRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        
        public bool checkProductCode(int codeProduct) {
            var product = _context.Product.FirstOrDefault(product => product.Code == codeProduct);
            if (product == null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool checkProductStock(int productid, int quantity)
        {
            var product = _context.Product.FirstOrDefault(product => product.Id == productid);
            if (product.Stock >= quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Product> GetStocks()
        {
            var stocks = _context.Product.Where(e => e.Stockable == true).ToList();
            return stocks;
        }
    }
}
