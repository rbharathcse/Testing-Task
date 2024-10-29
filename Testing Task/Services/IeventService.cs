using Ticket_Reservation.Data;
using Ticket_Reservation.Models;

namespace Testing_Task.Services
{
    public class IeventService
    {
        public interface IEventService
        {
            IEnumerable<Events> GetAllEvents();
            Events CreateEvent(Events eventItem);
        }
        public class EventService : IEventService
        {
            private readonly ApplicationDBContext dBContext;

            public EventService(ApplicationDBContext dBContext)
            {
                this.dBContext = dBContext;
            }

            public IEnumerable<Events> GetAllEvents()
            {
                return dBContext.Events.ToList();
            }

            public Events CreateEvent(Events eventItem)
            {
                dBContext.Events.Add(eventItem);
                dBContext.SaveChanges();
                return eventItem;
            }
        }
    }
}
