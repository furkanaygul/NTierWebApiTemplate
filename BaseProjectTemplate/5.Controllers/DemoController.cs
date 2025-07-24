using BaseProjectTemplate._4.ServiceLayer.DTOs;
using BaseProjectTemplate._4.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProjectTemplate._5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : BaseController
    {
        private readonly IApiDemoService _apiDemoService;
        public DemoController(IApiDemoService apiDemoService)
        {
            _apiDemoService = apiDemoService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _apiDemoService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _apiDemoService.GetByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DemoDto demoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _apiDemoService.CreateAsync(demoDto,"");
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] DemoDto demoDto)
        {
            
            await _apiDemoService.UpdateAsync(Id,demoDto,"");
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _apiDemoService.DeleteAsync(Id,"");
            return NoContent();
        }
    }
}
