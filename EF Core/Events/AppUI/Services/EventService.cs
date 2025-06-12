using DAL.Repositories.Interfaces;
using DAL.Models;

namespace AppUI.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepo;

        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public void AddEvent()
        {
            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Event Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Event Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Status (Active/In-Active): ");
            string status = Console.ReadLine();

            _eventRepo.AddEventUsingSP(name, category, date, description, status);
            Console.WriteLine("Event Added successfully.");
        }

        public void ViewAllEvents()
        {
            var events = _eventRepo.GetAllEvents();
            foreach (var e in events)
            {
                Console.WriteLine($"id: {e.EventId}, Event name: {e.EventName}, Event Date: {e.EventDate.ToShortDateString()}");
            }
        }
    }
}
