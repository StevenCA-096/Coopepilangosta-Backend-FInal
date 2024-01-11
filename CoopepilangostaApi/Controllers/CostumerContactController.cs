using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerContactController : ControllerBase
    {
        private readonly  ICostumerContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public CostumerContactController(ICostumerContactRepository costumerContactRepository,IMapper mapper)
        {
            _contactRepository = costumerContactRepository;
            _mapper = mapper;
        }

        // GET: api/<CostumerContactController>
        [HttpGet]
        public IEnumerable<CostumersContact> Get()
        {
            return _contactRepository.GetAll();
        }

        // GET api/<CostumerContactController>/5
        [HttpGet("{id}")]
        public CostumersContact Get(int id)
        {
            return _contactRepository.GetById(id);
        }

        // POST api/<CostumerContactController>
        [HttpPost]
        public async Task<CostumersContact> Post([FromBody] CostumerContactDTO costumerContactDTO)
        {
            var newContact = _mapper.Map<CostumerContactDTO, CostumersContact>(costumerContactDTO);
            _contactRepository.Insert(newContact);
            _contactRepository.Save();
            return newContact;
        }

        // PUT api/<CostumerContactController>/5
        [HttpPut]
        public void Put([FromBody] CostumerContactDTO costumerContactDTO)
        {
            var costumerContactfound = _contactRepository.GetById(costumerContactDTO.id);
            var CostumerContactUpdate = _mapper.Map(costumerContactDTO, costumerContactfound);
            _contactRepository.Update(CostumerContactUpdate);
            _contactRepository.Save();
        }

        // DELETE api/<CostumerContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactRepository.Delete(id);
            _contactRepository.Save();
        }
    }
}
