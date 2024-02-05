using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IReviewRepository: IGenericRepository<Review>
    {
        public IEnumerable<Review> GetAllData(int productid);
        public double GetAverage(int productid);

    }
}
