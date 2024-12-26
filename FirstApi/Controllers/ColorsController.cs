using FirstApi.DTOs.Color;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {
            return Ok(await _colorService.GetAllAsync(page, take));
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _colorService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateColorDTO colorDTO)
        {

            return Ok(_colorService.CreateAsync(colorDTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateColorDTO colorDTO)
        {
            _colorService.Update(id, colorDTO);
            return NoContent();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _colorService?.Delete(id);
            return NoContent();
        }
    }
}
