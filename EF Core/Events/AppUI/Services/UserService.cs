using DAL.Models;
using DAL.Repositories.Interfaces;

namespace AppUI.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void AddUser()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Role (Admin/Participant): ");
            string role = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            var user = new UserInfo
            {
                Email = email,
                Username = username,
                Role = role,
                Password = password
            };

            _userRepo.AddUser(user);
            Console.WriteLine("User Added Successfully");
        }

        public void ListAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"📧 {user.Email}, 👤 {user.Username}, 🎭 {user.Role}");
            }
        }
    }
}