using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repositories.Implementation
{
    public class EventRepository : IEventRepository
    {

        private readonly EventContext _context;

        public EventRepository(EventContext context) => _context = context;

        public void AddEventUsingSP(string name, string category, DateTime date, string description, string status)
        {
            _context.Database.ExecuteSqlRaw("EXEC InsertEventDetails @p0, @p1, @p2, @p3, @p4",
                name, category, date, description, status);
        }

        public void UpdateEventUsingSP(int eventId, string name, string category, DateTime date, string description, string status)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateEventDetails @p0, @p1, @p2, @p3, @p4, @p5",
                eventId, name, category, date, description, status);
        }

        public void DeleteEventUsingSP(int eventId)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteEventDetails @p0", eventId);
        }

        public EventDetails GetEventById(int id) => _context.Events.Find(id);

        public List<EventDetails> GetEventsByStatus(string status) =>
            _context.Events.Where(e => e.Status == status).ToList();

        public List<EventDetails> GetAllEvents() => _context.Events.ToList();
    }
}

