
using FirstApi.Repositories.Interfaces;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IRepository repository,ICategoryService categoryService)
        {
            _repository = repository;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _categoryService.GetAllAsync(page,take));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id < 1) return BadRequest();
            return Ok(await _categoryService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            _categoryService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] Category category)
        {
            if (id == null || id < 1) return BadRequest();
           _categoryService.Update(id, category);
            return NoContent();
        }
    }
}
