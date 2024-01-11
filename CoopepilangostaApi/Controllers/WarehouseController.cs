using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseController(IWarehouseRepository warehouseRepository, IMapper mapper) 
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Warehouse> Get()
        {        
            return _warehouseRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Warehouse Get(int id)
        {
            return _warehouseRepository.GetById(id);
        }

        [HttpGet("CheckCodeAvailabilityWarehouse")]
        public bool CheckCodeAvailabilityWarehouse(int code) {
            return _warehouseRepository.CheckCodeAvailabilityWarehouse(code);
        }
        [HttpPost]
        public void Post([FromBody] WarehouseDTO warehouseDTO)
        {
            var warehouse = _mapper.Map<WarehouseDTO, Warehouse>(warehouseDTO);
            _warehouseRepository.Insert(warehouse);
            _warehouseRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WarehouseDTO warehouseDTO)
        {
            var warehouse = _mapper.Map<WarehouseDTO, Warehouse>(warehouseDTO);
            _warehouseRepository.Update(warehouse);
            _warehouseRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _warehouseRepository.Delete(id);
            _warehouseRepository.Save();
        }
    }
}
