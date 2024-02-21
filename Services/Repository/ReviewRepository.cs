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

        public double GetAverage(int productid)
        {

            var review = _context.review.Where(e => e.ProductId == productid);
            var reviewcount = review.Count();

            if (reviewcount > 0)
            {
                int[] array = {

                   (review.Count(e => e.Stars == 1)),
                   (review.Count(e => e.Stars == 2)),
                   (review.Count(e => e.Stars == 3)),
                   (review.Count(e => e.Stars == 4)),
                   (review.Count(e => e.Stars == 5))

                   };

                int AverageReview = Array.IndexOf(array, array.Max()) +1;
                return AverageReview;
            }
            else return 0; 
        }

    }
}
