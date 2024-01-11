using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;
using Services.Repository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProducerController : ControllerBase
    {
        private readonly IProductProducerRepository _productproductRepository;
        private readonly IMapper _mapper;

        public ProductProducerController(IProductProducerRepository productproductRepository, IMapper mapper) 
        {
            _productproductRepository = productproductRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ProductProducer>> Get(int ProductId, int ProducerId)
        {
            var PurchasePrice = await _productproductRepository.ObtainPurchasePrice(ProductId, ProducerId);
            return PurchasePrice;

        }


        //[HttpGet]
        //public IEnumerable<ProductProducer> Get()
        //{
        //    return _productproductRepository.GetAll();
        //}


        //[HttpGet("{id}")]
        //public ProductProducer Get(int id)
        //{
        //    return _productproductRepository.GetById(id);
        //}

        [HttpGet("{id}")]
        public async Task<decimal> Get(int id)
        {
            return await _productproductRepository.ObtainPurchasePriceAverage(id);
        }


        [HttpPost]
        public void Post([FromBody] ProductProducerDTO productproducerdto)
        {
            var productproducer = _mapper.Map<ProductProducerDTO, ProductProducer>(productproducerdto);

            _productproductRepository.Insert(productproducer);
            _productproductRepository.Save();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int ProductId, int ProducerId, ProductProducerDTO productproducerdto)
        {
            var existing = await _productproductRepository.ObtainPurchasePrice(ProductId, ProducerId);

            _mapper.Map(productproducerdto, existing);

            _productproductRepository.Update(existing);
            _productproductRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productproductRepository.Delete(id);
            _productproductRepository.Save();
        }
    }
}
