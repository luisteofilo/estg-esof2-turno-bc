using Microsoft.AspNetCore.Mvc;
using WebAPI.DtoClasses;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseEventDto>>> GetEvents()
        {
            var _context = new ApplicationDbContext();
            var events = await _context.Events
                .Select(e => new ResponseEventDto
                {
                    EventId = e.EventId,
                    Name = e.Name,
                    Slug = e.Slug,
                    Description = e.Description,
                    BlindTasting = e.BlindTasting,
                    WineType = e.WineType
                })
                .ToListAsync();

            return Ok(events);
        }

        // GET: api/events/{slug}
        [HttpGet("{slug}")]
        public async Task<ActionResult<ResponseEventDto>> GetEvent(string slug)
        {
            var _context = new ApplicationDbContext();
            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Slug == slug);

            if (eventEntity == null)
            {
                return NotFound();
            }

            var eventDto = new ResponseEventDto
            {
                EventId = eventEntity.EventId,
                Name = eventEntity.Name,
                Slug = eventEntity.Slug,
                Description = eventEntity.Description,
                BlindTasting = eventEntity.BlindTasting,
                WineType = eventEntity.WineType
            };

            return Ok(eventDto);
        }

        // POST: api/events/create
        [HttpPost("create")]
        public async Task<ActionResult<ResponseEventDto>> CreateEvent(CreateEventDto createEventDto)
        {
            var _context = new ApplicationDbContext();
            var newEvent = new Event
            {
                Name = createEventDto.Name,
                Slug = createEventDto.Slug,
                Description = createEventDto.Description,
                BlindTasting = createEventDto.BlindTasting,
                WineType = createEventDto.WineType
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { slug = newEvent.Slug }, newEvent);
        }

        // PUT: api/events/{slug}
        [HttpPut("{slug}")]
        public async Task<IActionResult> UpdateEvent(string slug, UpdateEventDto updateEventDto)
        {
            var _context = new ApplicationDbContext();
            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Slug == slug);

            if (eventEntity == null)
            {
                return NotFound();
            }

            eventEntity.Name = updateEventDto.Name;
            eventEntity.Description = updateEventDto.Description;
            eventEntity.BlindTasting = updateEventDto.BlindTasting;
            eventEntity.WineType = updateEventDto.WineType;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/events/slug/{slug}
        [HttpDelete("slug/{slug}")]
        public async Task<IActionResult> DeleteEvent(string slug)
        {
            var _context = new ApplicationDbContext();
            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Slug == slug);

            if (eventEntity == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
