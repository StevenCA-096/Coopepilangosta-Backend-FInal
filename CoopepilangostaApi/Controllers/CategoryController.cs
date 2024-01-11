using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.IRepository;

namespace CoopepilangostaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {        
            return _categoryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] CategoryDTO categorydto)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categorydto);

            _categoryRepository.Insert(category);
            _categoryRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDTO categorydto)
        {

            var existing = _categoryRepository.GetById(id);

            _mapper.Map(categorydto, existing);

            _categoryRepository.Update(existing);
            _categoryRepository.Save();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
        }
    }
}
