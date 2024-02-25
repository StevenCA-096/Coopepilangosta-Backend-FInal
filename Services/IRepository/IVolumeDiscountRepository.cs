using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IVolumeDiscountRepository : IGenericRepository<VolumeDiscount>
    {
        public IEnumerable<VolumeDiscount> GetAllData(int productcostumerId);

    }
}
