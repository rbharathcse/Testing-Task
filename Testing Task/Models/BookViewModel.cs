namespace Ticket_Reservation.Models
{
    public class BookViewModel
    {
        public int EventId { get; set; }
        public int NumberOfTickets { get; set; }
        public string Reference { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
