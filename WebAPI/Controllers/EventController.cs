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
    [Route("api/events")]  // Specify the route explicitly
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
                    Slug = e.Slug
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
                Slug = eventEntity.Slug
            };

            return Ok(eventDto);
        }
        
        [HttpGet("register/{eventId}/{userId}")]
        public async Task<IActionResult> RegisterUserToEvent(Guid eventId, Guid? userId)
        {
            var _context = new ApplicationDbContext();
            if (!userId.HasValue || userId == Guid.Empty)
            {
                // Handling not logged-in users
                return Unauthorized("User not logged in.");
            }

            // Check if the user is already a participant
            var isParticipant = await _context.EventParticipants
                .AnyAsync(ep => ep.EventId == eventId && ep.UserId == userId.Value);
            
            if (isParticipant)
            {
                return Ok("Already Participating");
            }

            // Add user as a participant if not already
            var participant = new EventParticipant 
            {
                EventId = eventId,
                UserId = userId.Value
            };
            _context.EventParticipants.Add(participant);
            await _context.SaveChangesAsync();

            return Ok("Registration Successful");
        }
    }
}