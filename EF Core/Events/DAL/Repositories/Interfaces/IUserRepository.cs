using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserInfo user);
        void UpdateUser(UserInfo user);
        void DeleteUser(string email);
        UserInfo GetUserByEmail(string email);
        List<UserInfo> GetAllUsers();
    }
}
