using AutoMapper;
using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IRepository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerOrderController : ControllerBase
    {
        private readonly ICostumerOrderRepository _costumerorderRepository;
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public CostumerOrderController(ICostumerOrderRepository costumerorderRepository, IMapper mapper,ApiContext context) 
        {
            _costumerorderRepository = costumerorderRepository;
            _mapper = mapper;
            _context = context;
        }

        [Route("ByCostumer")]
        [HttpGet]
        public IEnumerable<CostumerOrder> GetAllData(int id)
        {
            return _costumerorderRepository.GetAllData(id);
        }

        [HttpGet]
        public IEnumerable<CostumerOrder> Get()
        {        
            return _costumerorderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public CostumerOrder Get(int id)
        {
            return _context.CostumerOrder.Include(cosdorder => cosdorder.sales)
                .ThenInclude(sale =>sale.Product)
                .Include(cosdorder => cosdorder.Costumer)
                .FirstOrDefault(cosdorder => cosdorder.Id == id)
                ;
        }

        [HttpPost]
        public async Task<ActionResult<CostumerDTO>> Post([FromBody] CostumerOrderDTO costumerorderdto)
        {
            var entry = _mapper.Map<CostumerOrderDTO, CostumerOrder>(costumerorderdto);

            _costumerorderRepository.Insert(entry);
            _costumerorderRepository.Save();
            return CreatedAtAction("Get", new { id = entry.Id }, entry);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CostumerOrderDTO costumerorderdto)
        {

            var existing = _costumerorderRepository.GetById(id);

            _mapper.Map(costumerorderdto, existing);

            _costumerorderRepository.Update(existing);
            _costumerorderRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _costumerorderRepository.Delete(id);
            _costumerorderRepository.Save();
        }
    }
}
