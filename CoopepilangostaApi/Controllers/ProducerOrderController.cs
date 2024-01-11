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
    public class ProducerOrderController : ControllerBase
    {
        private readonly IProducerOrderRepository _producerorderRepository;
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public ProducerOrderController(IProducerOrderRepository producerorderRepository, IMapper mapper,ApiContext context) 
        {
            _producerorderRepository = producerorderRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ProducerOrder> Get()
        {        
            return _producerorderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ProducerOrder Get(int id)
        {
            return _context.ProducerOrder.Include(prodorder => prodorder.purchases)
                .ThenInclude(purchase =>purchase.Product)
                .Include(prodorder => prodorder.Producer)
                .FirstOrDefault(prodorder => prodorder.Id == id)
                ;
        }

        [HttpPost]
        public async Task<ActionResult<ProducerDTO>> Post([FromBody] ProducerOrderDTO producerorderdto)
        {
            var entry = _mapper.Map<ProducerOrderDTO, ProducerOrder>(producerorderdto);

            _producerorderRepository.Insert(entry);
            _producerorderRepository.Save();
            return CreatedAtAction("Get", new { id = entry.Id }, entry);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProducerOrderDTO producerorderdto)
        {

            var existing = _producerorderRepository.GetById(id);

            _mapper.Map(producerorderdto, existing);

            _producerorderRepository.Update(existing);
            _producerorderRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _producerorderRepository.Delete(id);
            _producerorderRepository.Save();
        }
    }
}
