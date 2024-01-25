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
    public class ProductCostumerController : ControllerBase
    {
        private readonly IProductCostumerRepository _productcostumerRepository;
        private readonly IMapper _mapper;

        public ProductCostumerController(IProductCostumerRepository productcostumerRepository, IMapper mapper) 
        {
            _productcostumerRepository = productcostumerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ProductCostumer>> Get(int ProductId, int CostumerId)
        {
            var PurchasePrice = await _productcostumerRepository.ObtainPurchasePrice(ProductId, CostumerId);
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


        [HttpPost]
        public void Post([FromBody] ProductCostumerDTO productcostumerdto)
        {
            var productcostumer = _mapper.Map<ProductCostumerDTO, ProductCostumer>(productcostumerdto);

            _productcostumerRepository.Insert(productcostumer);
            _productcostumerRepository.Save();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int ProductId, int CostumerId, ProductCostumerDTO productcostumerdto)
        {
            var existing = await _productcostumerRepository.ObtainPurchasePrice(ProductId, CostumerId);

            _mapper.Map(productcostumerdto, existing);

            _productcostumerRepository.Update(existing);
            _productcostumerRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productcostumerRepository.Delete(id);
            _productcostumerRepository.Save();
        }
    }
}
