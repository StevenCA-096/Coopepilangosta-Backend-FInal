using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesController(IRoleRepository roleRepository,IMapper mapper) { 
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _roleRepository.GetAll();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return _roleRepository.GetById(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
