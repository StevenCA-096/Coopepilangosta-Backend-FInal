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
    public class VolumeDiscountRepository : GenericRepository<VolumeDiscount>, IVolumeDiscountRepository
    {
        public readonly ApiContext _context;
        public VolumeDiscountRepository(ApiContext context) : base(context)

        {
            _context = context;
        }
        public IEnumerable<VolumeDiscount> GetAllData(int productcostumerId)
        {
            var volumeDiscounts = _context.volumeDiscount.Where(e => e.ProductCostumerId == productcostumerId).ToList();
            return volumeDiscounts;
        }

    }
}

