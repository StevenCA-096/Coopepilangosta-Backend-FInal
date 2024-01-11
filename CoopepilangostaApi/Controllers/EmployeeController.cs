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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper) { 
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public Task<List<Employee>> Get()
        {
            return _employeeRepository.getAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeRepository.GetById(id);
        }

        [HttpGet("CheckEmployeeCedulaAvailability")]
        public bool CheckCedulaEmployeeAvailability(int cedula) {
            return _employeeRepository.CheckCedulaEmployee(cedula);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeDTO employeeDTO)
        {
            var newEmployee = _mapper.Map<EmployeeDTO,Employee>(employeeDTO);
            _employeeRepository.Insert(newEmployee);
            _employeeRepository.Save();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public void Put([FromBody] EmployeeDTO employeeDTO)
        {
            var employeeFound = _employeeRepository.GetById(employeeDTO.Id);
            var updateEmployee = _mapper.Map(employeeDTO,employeeFound);
            _employeeRepository.Update(updateEmployee);
            _employeeRepository.Save();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
        }
    }
}
