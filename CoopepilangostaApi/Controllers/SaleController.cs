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

        [Route("FilteredByProduct")]
        [HttpGet]
        public IEnumerable<FilteredSaleDTO> GetSalesByProduct(int productid)
        {
            return _saleRepository.GetSalesByProduct(productid);
        }

        [Route("FilteredByOrder")]
        [HttpGet]
        public IEnumerable<Sale> GetSalesByProducerOrder(int producerorderid)
        {
            return _saleRepository.GetSalesByProducerOrder(producerorderid);
        }

        [HttpPost]
        public void Post([FromBody] SaleDTO saledto)
        {
            var entry = _mapper.Map<SaleDTO, Sale>(saledto);

            _saleRepository.Insert(entry);
            _saleRepository.Save();
        }
    }
}
