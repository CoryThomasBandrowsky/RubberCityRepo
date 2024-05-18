using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RubberCity.Services.Services;

namespace RubberCityAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalHelpController : ControllerBase
    {
        private readonly LocalHelpService _localHelpService;

        public LocalHelpController(LocalHelpService localHelpService)
        {
            _localHelpService = localHelpService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocalHelp()
        {
            var localHelp = await _localHelpService.GetAllLocalHelp();
            return Ok(localHelp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalHelpById(int id)
        {
            var localHelp = await _localHelpService.GetLocalHelpById(id);
            if (localHelp == null)
            {
                return NotFound();
            }
            return Ok(localHelp);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocalHelp([FromBody] LocalHelp localHelp)
        {
            await _localHelpService.AddLocalHelp(localHelp);
            return CreatedAtAction(nameof(GetLocalHelpById), new { id = localHelp.Id }, localHelp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocalHelp(int id, [FromBody] LocalHelp localHelp)
        {
            if (id != localHelp.Id)
            {
                return BadRequest();
            }

            await _localHelpService.UpdateLocalHelp(localHelp);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalHelp(int id)
        {
            await _localHelpService.DeleteLocalHelp(id);
            return NoContent();
        }
    }
}
