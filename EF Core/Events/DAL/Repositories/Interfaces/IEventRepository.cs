using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IEventRepository
    {
        void AddEventUsingSP(string name, string category, DateTime date, string description, string status);
        void UpdateEventUsingSP(int eventId, string name, string category, DateTime date, string description, string status);
        void DeleteEventUsingSP(int eventId);
        EventDetails GetEventById(int id);
        List<EventDetails> GetEventsByStatus(string status);
        List<EventDetails> GetAllEvents();
    }
}
