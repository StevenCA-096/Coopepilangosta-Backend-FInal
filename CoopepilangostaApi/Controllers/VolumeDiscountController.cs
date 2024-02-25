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
    public class VolumeDiscountController : ControllerBase
    {
        private readonly IVolumeDiscountRepository _volumeDiscountRepository;
        private readonly IMapper _mapper;

        public VolumeDiscountController(IVolumeDiscountRepository volumeDiscountRepository, IMapper mapper) 
        {
            _volumeDiscountRepository = volumeDiscountRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<VolumeDiscount> Get(int productcostumerid)
        {
            return _volumeDiscountRepository.GetAllData(productcostumerid);
        }

        [HttpGet("{id}")]
        public VolumeDiscount GetById(int id)
        {
            return _volumeDiscountRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] VolumeDiscountDTO volumediscountdto)
        {
            var volumediscount = _mapper.Map<VolumeDiscountDTO, VolumeDiscount>(volumediscountdto);

            _volumeDiscountRepository.Insert(volumediscount);
            _volumeDiscountRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VolumeDiscountDTO volumediscountdto)
        {
            var existing = _volumeDiscountRepository.GetById(id);

            _mapper.Map(volumediscountdto, existing);

            _volumeDiscountRepository.Update(existing);
            _volumeDiscountRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _volumeDiscountRepository.Delete(id);
            _volumeDiscountRepository.Save();
        }
    }
}
