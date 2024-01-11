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
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public ProducerController(IProducerRepository producerRepository, IMapper mapper) 
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Producer> Get()
        {        
            return _producerRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Producer Get(int id)
        {
            return _producerRepository.GetById(id);
        }

        [HttpGet("CheckCedulaAvailability")]
        public bool CheckCedulaAvailability(int cedula) {
            return _producerRepository.CheckCedulaAvailability(cedula);
        }

        [HttpPost]
        public void Post([FromBody] ProducerDTO producerdto)
        {
            var producer = _mapper.Map<ProducerDTO, Producer>(producerdto);

            _producerRepository.Insert(producer);
            _producerRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProducerDTO producerdto)
        {
            var existing = _producerRepository.GetById(id);

            _mapper.Map(producerdto, existing);

            _producerRepository.Update(existing);
            _producerRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _producerRepository.Delete(id);
            _producerRepository.Save();
        }
    }
}
