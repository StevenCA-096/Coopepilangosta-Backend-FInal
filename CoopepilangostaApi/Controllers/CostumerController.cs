using AutoMapper;
using DataAccess.Data;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IRepository;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
        
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _mapper;
        
        public CostumerController(ICostumerRepository costumerRepository,IMapper mapper) { 
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        // GET: api/<CostumerController>
        [HttpGet]
        public Task<List<Costumer>> Get()
        {
            return _costumerRepository.GetAllData(); 
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public Costumer Get(int id)
        {
            return _costumerRepository.GetById(id);
        }

        [HttpGet("checkCedula")]
        public bool checkCedula(int id)
        {
            return _costumerRepository.checkCedula(id);
        }

        // POST api/<CostumerController>
        [HttpPost]
        public async Task<ActionResult<Costumer>> Post([FromBody] CostumerDTO costumerDTO)
        {
            var newCostumer = _mapper.Map<CostumerDTO,Costumer>(costumerDTO);

            var result = _costumerRepository.createCostumer(newCostumer);
            _costumerRepository.Save();
            return StatusCode(result);
        }

        // PUT api/<CostumerController>/5
        [HttpPut]
        public void Put([FromBody] CostumerDTO costumerDTO)
        {
            var costumerFind = _costumerRepository.GetById(costumerDTO.id);
            var costumerUpdate = _mapper.Map(costumerDTO,costumerFind);
            _costumerRepository.Update(costumerUpdate);
            _costumerRepository.Save();
        }

        // DELETE api/<CostumerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _costumerRepository.Delete(id);
            _costumerRepository.Save();
        }
    }
}
