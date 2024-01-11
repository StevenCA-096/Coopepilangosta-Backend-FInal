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
    internal class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly ApiContext _context;
        public WarehouseRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckCodeAvailabilityWarehouse(int code) {
            var warehouse = _context.Warehouse.FirstOrDefault(warehouse => warehouse.Code == code);
            if (warehouse == null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        //public List<IGrouping<int, Entry>> GetWarehouseEntries()
        //{          
        //    var listWarehouse = _context.Warehouse.Include(w => w.entries).ToList();
            

        //    foreach (var warehouse in listWarehouse)
        //    {
        //        var entries = warehouse.entries;
        //        foreach (var entry in entries)
        //        {
        //            entry.ProductId = 0;
        //        }
        //    }
        //}

    }
}
