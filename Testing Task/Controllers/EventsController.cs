using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Reservation.Models;
using static Testing_Task.Services.IeventService;

namespace Ticket_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Events eventItem)
        {
            var createdEvent = eventService.CreateEvent(eventItem);
            return CreatedAtAction(nameof(GetEvents), new { id = createdEvent.Id }, createdEvent);
        }
    }
}
