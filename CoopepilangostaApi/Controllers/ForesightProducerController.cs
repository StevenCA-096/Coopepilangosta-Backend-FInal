using AutoMapper;
using DataAccess.Data;
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
    public class ForesightProducerController : ControllerBase
    {

        private readonly IForesightProducerRepository _foresightProducerRepository;
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ForesightProducerController(IForesightProducerRepository foresightProducerRepository, IMapper mapper, ApiContext context)
        {
            _foresightProducerRepository = foresightProducerRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ForesightProducer> Get()
        {
            return _foresightProducerRepository.GetAll();
        }

        // GET api/<ForesightProducerController>/5
        [HttpGet("{id}")]
        public ForesightProducer Get(int id)
        {
            return _foresightProducerRepository.GetById(id);
        }

        // POST api/<ForesightProducerController>
        [HttpPost]
        public async Task<ActionResult<ForesightProducerDTO>> Post([FromBody] ForesightProducerDTO foresightProducerDTO)
        {
            var newForesightproducer = _mapper.Map<ForesightProducerDTO, ForesightProducer>(foresightProducerDTO);

            var foresightProdFound = _context.foresightProducer.Where(
                fp => fp.producer.Id == foresightProducerDTO.ProducerId && fp.ForesightId == foresightProducerDTO.ForesightId
                ).FirstOrDefault();

            if (foresightProdFound == null)
            {
                _foresightProducerRepository.Insert(newForesightproducer);
                _foresightProducerRepository.Save();
                return CreatedAtAction("Get", new { id = newForesightproducer.Id }, newForesightproducer);
            }
            else
            {
                return foresightProducerDTO;
            }


        }

        // PUT api/<ForesightProducerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ForesightProducerController>/5
        [HttpDelete("{id}")]
       
            public string Delete(int id)
            {
                var exist = _foresightProducerRepository.GetById(id);
                if (exist != null)
                {
                    _foresightProducerRepository.Delete(id);
                    _foresightProducerRepository.Save();
                    return "Deleted succesfully";
                }
                else
                {
                    return "Doesnt exist";
                }


            }
        
    }
}
