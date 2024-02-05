using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Repository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApiContext _context;

        public SaleRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetSalesByProducerOrder(int id)
        {
            var sales = _context.Sale.Where(e => e.CostumerOrderId == id).ToList();
            return sales;
        }


        public IEnumerable<FilteredSaleDTO> GetSalesByProduct(int id)
        {
            var sales = new List<Sale>();
            var filteredsales = new List<FilteredSaleDTO>();

                sales = _context.Sale.Where(e => e.ProductId == id).ToList();

                foreach (var sale in sales){

                 var costumerorder = _context.CostumerOrder.Include(cosdorder => cosdorder.sales)
                .ThenInclude(sale => sale.Product)
                .FirstOrDefault(cosdorder => cosdorder.Id == sale.CostumerOrderId)
                ;
                    FilteredSaleDTO filteredSale = new FilteredSaleDTO();
                    filteredSale.Quantity = sale.Quantity;
                    filteredSale.PurchaseTotal = sale.PurchaseTotal;
                    filteredSale.Date = costumerorder.ConfirmedDate;

                    filteredsales.Add(filteredSale);
                }

            return filteredsales;
        }
    }
}
