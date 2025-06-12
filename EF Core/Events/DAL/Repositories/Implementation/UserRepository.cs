using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly EventContext _context;

        public UserRepository(EventContext context) => _context = context;

        public void AddUser(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserInfo user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string email)
        {
            var user = _context.Users.Find(email);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public UserInfo GetUserByEmail(string email) => _context.Users.Find(email);



        public List<UserInfo> GetAllUsers() => _context.Users.ToList(); 
    }
}
