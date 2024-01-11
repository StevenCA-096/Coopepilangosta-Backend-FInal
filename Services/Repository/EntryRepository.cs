using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class EntryRepository : GenericRepository<Entry> , IEntryRepository
    {
        private readonly ApiContext _context;
        public EntryRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public int InsertEntry(Entry entry) {
            
            var product = _context.Product.Where(p => p.Id == entry.ProductId).FirstOrDefault();
            var entryCheck = _context.Entry.Where(e => e.ProducerOrderId == entry.ProducerOrderId && e.ProductId == entry.ProductId);
            if (product != null && entryCheck.IsNullOrEmpty())
            {
                product.Stock = product.Stock + (int)entry.Quantity;

                _context.Entry.Add(entry);
                _context.Product.Update(product);

                var resultEntry = _context.SaveChanges();
                
                return 1;
            }
            else {
                return 0;
            }
            
        }

        public int CheckEntryDone(int idProducerOrder, int idProduct)
        {
           var existing = _context.Entry.Where(e => e.ProducerOrderId == idProducerOrder && e.ProductId == idProduct).FirstOrDefault();
            if (existing != null)
            {
                return 1;
            }
            else {
                return 0;
            }
        }

        public List<IGrouping<int,Entry>> GetEntries()
        {
            var entries = _context.Entry.GroupBy(e => e.WarehouseId).ToList();
            foreach (var entry in entries)
            {
                entry.Sum(e => e.Quantity);
            }
            return entries;
        }
    }
}
