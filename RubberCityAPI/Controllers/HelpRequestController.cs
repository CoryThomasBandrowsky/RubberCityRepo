using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using RubberCity.Services.Services;
using System.Threading.Tasks;

namespace RubberCityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelpRequestController : ControllerBase
    {
        private readonly HelpRequestService _helpRequestService;
        private readonly ILogger<HelpRequestController> _logger;

        public HelpRequestController(HelpRequestService helpRequestService, ILogger<HelpRequestController> logger)
        {
            _helpRequestService = helpRequestService;
            _logger = logger;
        }

        // GET: /HelpRequests/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var helpRequest = await _helpRequestService.GetByIdAsync(id);
            if (helpRequest == null)
            {
                return NotFound($"Help Request with ID {id} not found.");
            }

            return Ok(helpRequest);
        }

        // GET: /HelpRequests
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var helpRequests = await _helpRequestService.GetAllAsync();
            return Ok(helpRequests);
        }

        // POST: /HelpRequests
        [HttpPost("/helprequest/add")]
        public async Task<IActionResult> Add(HelpRequestModel helpRequest)
        {
            await _helpRequestService.AddHelpRequestAsync(helpRequest);
            return CreatedAtAction(nameof(GetById), new { id = helpRequest.ID }, helpRequest);
        }

        // PUT: /HelpRequests/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HelpRequestModel helpRequest)
        {
            if (id != helpRequest.ID)
            {
                return BadRequest("Help Request ID mismatch");
            }

            var existingHelpRequest = await _helpRequestService.GetByIdAsync(id);
            if (existingHelpRequest == null)
            {
                return NotFound($"Help Request with ID {id} not found.");
            }

            await _helpRequestService.UpdateHelpRequestAsync(helpRequest);
            return NoContent();
        }

        // DELETE: /HelpRequests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var helpRequest = await _helpRequestService.GetByIdAsync(id);
            if (helpRequest == null)
            {
                return NotFound($"Help Request with ID {id} not found.");
            }

            await _helpRequestService.DeleteHelpRequestAsync(helpRequest);
            return NoContent();
        }
    }
}
