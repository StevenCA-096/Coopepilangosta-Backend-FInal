using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IRepository;
using Services.Repository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper) 
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Review> Get(int productid)
        {
            return _reviewRepository.GetAllData(productid);
        }

        [HttpPost]
        public void Post([FromBody] ReviewDTO reviewdto)
        {
            var review = _mapper.Map<ReviewDTO, Review>(reviewdto);

            _reviewRepository.Insert(review);
            _reviewRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReviewDTO reviewdto)
        {
            var existing = _reviewRepository.GetById(id);

            _mapper.Map(reviewdto, existing);

            _reviewRepository.Update(existing);
            _reviewRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
            _reviewRepository.Save();
        }
    }
}
