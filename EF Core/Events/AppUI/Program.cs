using AppUI.Services;
using DAL;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;

namespace AppUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new EventContext();

            IUserRepository userRepo = new UserRepository(context);
            IEventRepository eventRepo = new EventRepository(context);
            ISessionRepository sessionRepo = new SessionRepository(context);

            var userService = new UserService(userRepo);
            var eventService = new EventService(eventRepo);
            var sessionService = new SessionService(sessionRepo);

            bool running = true;

            while (running)
            {
                Console.WriteLine("----MAIN MENU ----");
                Console.WriteLine("1. User Menu");
                Console.WriteLine("2. Event Menu");
                Console.WriteLine("3. Session Menu");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        UserMenu(userService);
                        break;
                    case "2":
                        EventMenu(eventService);
                        break;
                    case "3":
                        SessionMenu(sessionService);
                        break;
                    case "0":
                        Console.WriteLine("Exiting program...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❗ Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void UserMenu(UserService userService)
        {
            bool userRunning = true;
            while (userRunning)
            {
                Console.WriteLine("--- USER MENU ---");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. List All Users");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        userService.AddUser();
                        break;
                    case "2":
                        userService.ListAllUsers();
                        break;
                    case "0":
                        userRunning = false;
                        break;
                    default:
                        Console.WriteLine("❗ Invalid option.");
                        break;
                }
            }
        }

        static void EventMenu(EventService eventService)
        {
            bool eventRunning = true;
            while (eventRunning)
            {
                Console.WriteLine("--- EVENT MENU ---");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. View All Events");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        eventService.AddEvent();
                        break;
                    case "2":
                        eventService.ViewAllEvents();
                        break;
                    case "0":
                        eventRunning = false;
                        break;
                    default:
                        Console.WriteLine("❗ Invalid option.");
                        break;
                }
            }
        }

        static void SessionMenu(SessionService sessionService)
        {
            bool sessionRunning = true;
            while (sessionRunning)
            {
                Console.WriteLine("--- SESSION MENU ---");
                Console.WriteLine("1. Add Session");
                Console.WriteLine("2. View Sessions by Event ID");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sessionService.AddSession();
                        break;
                    case "2":
                        sessionService.ViewSessionsByEventId();
                        break;
                    case "0":
                        sessionRunning = false;
                        break;
                    default:
                        Console.WriteLine("❗ Invalid option.");
                        break;
                }
            }
        }
    }
}
