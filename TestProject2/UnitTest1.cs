using Microsoft.EntityFrameworkCore;
using static Testing_Task.Services.IbookingService;
using Ticket_Reservation.Data;
using Ticket_Reservation.Models;

namespace TestProject2
{
    public class Tests
    {
        private ApplicationDBContext _dbContext;
        private BookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new ApplicationDBContext(options);
            _bookingService = new BookingService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
            
        }

        [Test]
        public void CreateBooking_AddsBooking()
        {
           
            var booking = new Bookings { EventId = 1, NumberOfTickets = 2, Reference = "ABC123", BookingDate = DateTime.Now };
            var createdBooking = _bookingService.CreateBooking(booking);
            Assert.AreEqual(1, _dbContext.Bookings.Count());
            Assert.AreEqual("ABC123", createdBooking.Reference);
        }

        [Test]
        public void GetAllBookings_ReturnsAllBookings()
        {
            
            var bookingsList = new List<Bookings>
            {
                new Bookings { Id = 3, EventId = 1, NumberOfTickets = 2, Reference = "ABC123", BookingDate = DateTime.Now },
                new Bookings { Id = 2, EventId = 2, NumberOfTickets = 3, Reference = "XYZ456", BookingDate = DateTime.Now }
            };

            _dbContext.Bookings.AddRange(bookingsList);
            _dbContext.SaveChanges();

            // Act
            var result = _bookingService.GetAllBookings();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void DeleteBooking_RemovesBooking()
        {
            // Arrange
            var booking = new Bookings { Id = 1, EventId = 1, NumberOfTickets = 2, Reference = "ABC123", BookingDate = DateTime.Now };
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();

            // Act
            _bookingService.DeleteBooking(booking.Id);

            // Assert
            Assert.AreEqual(0, _dbContext.Bookings.Count());
        }
    }
}