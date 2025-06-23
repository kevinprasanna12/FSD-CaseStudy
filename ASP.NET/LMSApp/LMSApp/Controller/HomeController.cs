using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index() => View();

        public IActionResult AboutUs() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult AdminLogin() => RedirectToAction("Dashboard", "Admin");

        public IActionResult TrainerLogin() => RedirectToAction("Dashboard", "Trainer");

        public IActionResult LearnerLogin() => RedirectToAction("Dashboard", "Learner");
    }
}
