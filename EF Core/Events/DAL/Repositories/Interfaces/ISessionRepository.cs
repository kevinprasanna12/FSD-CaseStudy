using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        void AddSession(SessionInfo session);
        List<SessionInfo> GetSessionsByEventId(int eventId);
        List<SessionInfo> GetAllSessions();
    }
}
