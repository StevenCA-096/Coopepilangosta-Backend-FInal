using DataAccess.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        public IEnumerable<FilteredSaleDTO> GetSalesByProduct(int id);
        public IEnumerable<Sale> GetSalesByProducerOrder(int id);


    }
}
