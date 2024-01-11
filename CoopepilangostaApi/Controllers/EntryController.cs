using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;
        public EntryController(IEntryRepository entryRepository, IMapper mapper) 
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Entry> Get()
        {        
            return _entryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Entry Get(int id)
        {
            return _entryRepository.GetById(id);
        }

        [HttpGet("CheckEntryStatus")]
        public int CheckEntryDone(int idProducerOrder, int idProduct) {
            return _entryRepository.CheckEntryDone(idProducerOrder, idProduct);           
        }
        [HttpGet("GroupEntries")]
        public List<IGrouping<int, Entry>> GetEntries() {
            return _entryRepository.GetEntries();
        }
        [HttpPost]
        public IActionResult Post([FromBody] EntryDTO entrydto)
        {
            var entry = _mapper.Map<EntryDTO, Entry>(entrydto);
            
            var result = _entryRepository.InsertEntry(entry);

            if (result == 1)
            {
                return Ok(entry);
            }
            else {
                return Conflict("El producto del pedido ya fue agregado");
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EntryDTO entrydto)
        {

            var existing = _entryRepository.GetById(id);

            _mapper.Map(entrydto, existing);

            _entryRepository.Update(existing);
            _entryRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _entryRepository.Delete(id);
            _entryRepository.Save();
        }
    }
}
