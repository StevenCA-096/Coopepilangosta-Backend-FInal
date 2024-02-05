using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;
using Services.Repository;

namespace CoopepilangostaApi.Controllers
{
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public SaleController(ISaleRepository saleRepository, IMapper mapper) 
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        //[HttpGet]
        //public IEnumerable<Sale> Get()
        //{
        //    return _saleRepository.GetAll();
        //}

        [Route("api/FilteredByProduct")]
        [HttpGet]
        public IEnumerable<FilteredSaleDTO> GetSalesByProduct(int productid)
        {
            return _saleRepository.GetSalesByProduct(productid);
        }

        [Route("api/FilteredByOrder")]
        [HttpGet]
        public IEnumerable<Sale> GetSalesByProducerOrder(int producerorderid)
        {
            return _saleRepository.GetSalesByProducerOrder(producerorderid);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody] SaleDTO saledto)
        {
            var entry = _mapper.Map<SaleDTO, Sale>(saledto);

            _saleRepository.Insert(entry);
            _saleRepository.Save();
        }
    }
}
