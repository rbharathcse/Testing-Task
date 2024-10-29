namespace Ticket_Reservation.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}
