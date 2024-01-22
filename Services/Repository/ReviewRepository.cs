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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly ApiContext _context;

        public ReviewRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAllData(int productid)
        {
            var reviews = _context.review.Where(e => e.ProductId == productid).ToList();
            return reviews;
        }
    }
}
