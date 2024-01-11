using AutoMapper;
using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.IRepository;
using Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForesightController : ControllerBase
    {
        private readonly IForesightRepository _foresightRepository;
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ForesightController(IForesightRepository foresightRepository, IMapper mapper, ApiContext context)
        {
            _foresightRepository = foresightRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Foresight> Get()
        {
            return _foresightRepository.GetAll();
        }

        // GET api/<ForesightController>/5
        [HttpGet("{id}")]
        public Foresight Get(int id)
        {

            IEnumerable<Foresight> foresights = new List<Foresight>();
            foresights = _context.foresight.Include(f => f.Foresightproducers).ThenInclude(fprod => fprod.producer)
            .ToList().Where(foresight => foresight.IdProduct == id);

            Foresight foresight = new Foresight();
            if (!foresights.IsNullOrEmpty())
            {
                foresight = foresights.Last();
            }
            
            return foresight;
        }

        // POST api/<ForesightController>
        [HttpPost]
        public async Task<ActionResult<Foresight>> Post([FromBody] ForesightDTO foresightDTO)
        {
            var newForesight = _mapper.Map<ForesightDTO, Foresight>(foresightDTO);

            var foresightFound = _context.foresight.Where(f => f.IdProduct == foresightDTO.IdProduct).FirstOrDefault();
            if (foresightFound == null)
            {
                _foresightRepository.Insert(newForesight);
                _foresightRepository.Save();
                return CreatedAtAction("Get", new { id = newForesight.Id }, newForesight);
            }
            else {
                foresightFound.IdProduct = foresightDTO.IdProduct;
                foresightFound.endDate = foresightDTO.endDate;
                foresightFound.initialDate = foresightDTO.initialDate;
                _foresightRepository.Update(foresightFound);
                _foresightRepository.Save();
                return foresightFound;
            }
            
        }

        // PUT api/<ForesightController>/5
        [HttpPut]
        public void Put([FromBody] ForesightDTO foresightDTO)
        {
            var foresightFound = _foresightRepository.GetById(foresightDTO.Id);
            _mapper.Map(foresightDTO, foresightFound);
            _foresightRepository.Update(foresightFound);
            _foresightRepository.Save();
        }

        // DELETE api/<ForesightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
