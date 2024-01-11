using DataAccess.Data;
using DataAccess.Models;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class StockReportRepository : GenericRepository<StockReport>, IStockReportRepository
    {
        public StockReportRepository(ApiContext context) : base(context)
        {
        }
    }
}
