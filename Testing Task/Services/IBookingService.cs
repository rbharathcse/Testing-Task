using Ticket_Reservation.Data;
using Ticket_Reservation.Models;

namespace Testing_Task.Services
{
    public class IbookingService
    {
        public interface IBookingService
        {
            Bookings CreateBooking(Bookings booking);
            IEnumerable<Bookings> GetAllBookings();
            void DeleteBooking(int id);
        }
        public class BookingService : IBookingService
        {
            private readonly ApplicationDBContext dbContext;

            public BookingService(ApplicationDBContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Bookings CreateBooking(Bookings booking)
            {
                dbContext.Bookings.Add(booking);
                dbContext.SaveChanges();
                return booking;
            }

            public IEnumerable<Bookings> GetAllBookings()
            {
                return dbContext.Bookings.ToList();
            }

            public void DeleteBooking(int id)
            {
                var booking = dbContext.Bookings.Find(id);
                if (booking != null)
                {
                    dbContext.Bookings.Remove(booking);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
