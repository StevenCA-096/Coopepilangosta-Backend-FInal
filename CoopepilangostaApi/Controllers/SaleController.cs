using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

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

        [HttpGet]
        public IEnumerable<Sale> Get()
        {        
            return _saleRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Sale Get(int id)
        {
            return _saleRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] SaleDTO saledto)
        {
            var entry = _mapper.Map<SaleDTO, Sale>(saledto);

            _saleRepository.Insert(entry);
            _saleRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SaleDTO saledto)
        {

            var existing = _saleRepository.GetById(id);

            _mapper.Map(saledto, existing);

            _saleRepository.Update(existing);
            _saleRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _saleRepository.Delete(id);
            _saleRepository.Save();
        }
    }
}
