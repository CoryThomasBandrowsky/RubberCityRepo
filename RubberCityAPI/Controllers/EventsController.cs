using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RubberCity.Services.Services;
using System.Threading.Tasks;

namespace RubberCityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventEntityService;

        public EventsController(EventService eventEntityService)
        {
            _eventEntityService = eventEntityService;
        }

        [HttpGet("/events/getAll")]
        public async Task<IActionResult> GetAllEvents()
        {
            var eventEntitys = await _eventEntityService.GetAllEvents();
            return Ok(eventEntitys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventEntity = await _eventEntityService.GetEventById(id);
            if (eventEntity == null)
            {
            return NotFound();
        }
            return Ok(eventEntity);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event eventEntity)
        {
            await _eventEntityService.AddEvent(eventEntity);
            return CreatedAtAction(nameof(GetEventById), new { id = eventEntity.ID }, eventEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event eventEntity)
        {
            if (id != eventEntity.ID)
            {
            return BadRequest();
        }

        await _eventEntityService.UpdateEvent(eventEntity);
            return NoContent();
        }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var eventEntity = await _eventEntityService.GetEventById(id);
        if (eventEntity == null)
            {
            return NotFound();
        }

        await _eventEntityService.DeleteEvent(id);
        return NoContent();
    }
}
}
