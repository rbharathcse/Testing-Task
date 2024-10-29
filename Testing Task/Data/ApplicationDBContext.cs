using Microsoft.EntityFrameworkCore;
using Ticket_Reservation.Models;

namespace Ticket_Reservation.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        public DbSet<Events> Events { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

    }
}
