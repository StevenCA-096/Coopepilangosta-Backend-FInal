using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;
using Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : ControllerBase
    {
        private readonly IStockReportRepository _stockreportRepository;
        private readonly IMapper _mapper;
        public StockReportController(IStockReportRepository stockreportRepository, IMapper mapper)
        {
            _stockreportRepository = stockreportRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StockReport> Get()
        {
            return _stockreportRepository.GetAll();
        }

        [HttpGet("{id}")]
        public StockReport Get(int id)
        {
            return _stockreportRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] StockReportDTO stockreportdto)
        {
            var entry = _mapper.Map<StockReportDTO, StockReport>(stockreportdto);

            _stockreportRepository.Insert(entry);
            _stockreportRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StockReportDTO stockreportdto)
        {

            var existing = _stockreportRepository.GetById(id);

            _mapper.Map(stockreportdto, existing);

            _stockreportRepository.Update(existing);
            _stockreportRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _stockreportRepository.Delete(id);
            _stockreportRepository.Save();
        }
    }
}
