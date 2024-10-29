using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ticket_Reservation.Models;
using static Testing_Task.Services.IbookingService;

namespace Ticket_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Bookings bookings)
        {
            if (bookings == null)
            {
                return BadRequest("Booking data is required.");
            }

            var createdBooking = bookingService.CreateBooking(bookings);
            return Ok(createdBooking);
        }

        [HttpGet]
        public IActionResult Display()
        {
            var bookings = bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bookingService.DeleteBooking(id);
            return Ok();
        }
    }
}
