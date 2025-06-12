using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Models;

namespace DAL.Repositories.Implementation
{
    public class SessionRepository : ISessionRepository
    {
        private readonly EventContext _context;

        public SessionRepository(EventContext context) => _context = context;

        public void AddSession(SessionInfo session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }
        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _context.Sessions
                .Where(s => s.EventId == eventId)
                .ToList();
        }
        public List<SessionInfo> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }
    }
}
