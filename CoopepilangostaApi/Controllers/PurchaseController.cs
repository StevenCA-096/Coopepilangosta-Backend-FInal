using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        public PurchaseController(IPurchaseRepository purchaseRepository, IMapper mapper) 
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Purchase> Get()
        {        
            return _purchaseRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Purchase Get(int id)
        {
            return _purchaseRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] PurchaseDTO purchasedto)
        {
            var entry = _mapper.Map<PurchaseDTO, Purchase>(purchasedto);

            _purchaseRepository.Insert(entry);
            _purchaseRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PurchaseDTO entrydto)
        {

            var existing = _purchaseRepository.GetById(id);

            _mapper.Map(entrydto, existing);

            _purchaseRepository.Update(existing);
            _purchaseRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _purchaseRepository.Delete(id);
            _purchaseRepository.Save();
        }
    }
}
