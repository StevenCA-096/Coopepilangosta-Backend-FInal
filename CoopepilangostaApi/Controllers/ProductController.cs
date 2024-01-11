using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;
using Services.Repository;
using System.ComponentModel.DataAnnotations;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper) 
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {        
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.GetById(id);
        }

        [HttpGet("CheckCodeAvailability")]
        public bool CheckCodeAvailabilty(int code) {
            return _productRepository.checkProductCode(code);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO productdto)
        {
            var product = _mapper.Map<ProductDTO, Product>(productdto);
            try
            {
                _productRepository.Insert(product);
                _productRepository.Save();
                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDTO productdto)
        {
            var existing = _productRepository.GetById(id);

            _mapper.Map(productdto, existing);

            _productRepository.Update(existing);
            _productRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }
}
