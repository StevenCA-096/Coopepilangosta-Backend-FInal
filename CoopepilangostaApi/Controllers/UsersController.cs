using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;
using Services.Repository;
using System.Drawing.Printing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _iuserRepository;
        private readonly IMapper _mapper;
        
        public UsersController(IUserRepository iuserRepository, IMapper mapper)
        {
            _iuserRepository = iuserRepository; 
            _mapper = mapper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _iuserRepository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            return _iuserRepository.getUserById(id);
        }

        [HttpGet("CheckEmailAvailability")]
        public bool checkEmailExistence(string email) { 
            return _iuserRepository.checkEmailExistence(email);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDTO newUser)
        {
            string result = string.Empty;         
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(newUser.Password);
            result = Convert.ToBase64String(encryted);
            var user = _mapper.Map<UserDTO,User>(newUser);
            user.Password = result;
            
            _iuserRepository.Insert(user);
            _iuserRepository.Save();
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public void Put([FromBody] UserDTO userDto)
        {
            var userFound = _iuserRepository.GetById(userDto.Id);

            _mapper.Map(userDto, userFound);

            _iuserRepository.Update(userFound);
            _iuserRepository.Save();

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _iuserRepository.Delete(id);
            _iuserRepository.Save();
        }
    }
}
