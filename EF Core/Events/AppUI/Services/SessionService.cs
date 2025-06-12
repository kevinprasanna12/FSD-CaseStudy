using DAL.Models;
using DAL.Repositories.Interfaces;

namespace AppUI.Services
{
    public class SessionService
    {
        private readonly ISessionRepository _sessionRepo;

        public SessionService(ISessionRepository sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        public void AddSession()
        {
            Console.Write("Enter Event ID: ");
            int eventId = int.Parse(Console.ReadLine());

            Console.Write("Enter Session Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Speaker ID (or leave blank): ");
            string speakerInput = Console.ReadLine();
            int? speakerId = string.IsNullOrEmpty(speakerInput) ? null : int.Parse(speakerInput);

            Console.Write("Enter Start Time (yyyy-mm-dd HH:mm): ");
            DateTime start = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter End Time (yyyy-mm-dd HH:mm): ");
            DateTime end = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Session URL (optional): ");
            string url = Console.ReadLine();

            var session = new SessionInfo
            {
                EventId = eventId,
                SessionTitle = title,
                SpeakerId = speakerId,
                SessionStart = start,
                SessionEnd = end,
                SessionUrl = url
            };

            _sessionRepo.AddSession(session);
            Console.WriteLine("Session Added.");
        }

        public void ViewSessionsByEventId()
        {
            Console.Write("Enter Event ID: ");
            int id = int.Parse(Console.ReadLine());

            var sessions = _sessionRepo.GetSessionsByEventId(id);
            foreach (var s in sessions)
            {
                Console.WriteLine($" Session Title: {s.SessionTitle} Session Start Date: {s.SessionStart:t} Session End Date: {s.SessionEnd:t}");
            }
        }
    }
}
