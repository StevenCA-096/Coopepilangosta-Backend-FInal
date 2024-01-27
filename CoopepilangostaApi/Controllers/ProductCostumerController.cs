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
        public IEnumerable<ProductCostumer> Get(int costumerid)
        {
            return _productcostumerRepository.GetAllData(costumerid);
        }

        [HttpGet("{productId},{costumerId}")]
        public IEnumerable<ProductCostumer> GetByBothId(int productId, int costumerId)
        {
            return _productcostumerRepository.GetByBothId(productId, costumerId);
        }

        [HttpGet("{id}")]
        public ProductCostumer GetById(int id)
        {
            return _productcostumerRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ProductCostumerDTO productcostumerdto)
        {
            var productcostumer = _mapper.Map<ProductCostumerDTO, ProductCostumer>(productcostumerdto);

            _productcostumerRepository.Insert(productcostumer);
            _productcostumerRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductCostumerDTO productcostumerdto)
        {
            var existing = _productcostumerRepository.GetById(id);

            _mapper.Map(productcostumerdto, existing);

            _productcostumerRepository.Update(existing);
            _productcostumerRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productcostumerRepository.Delete(id);
            _productcostumerRepository.Save();
        }
    }
}
