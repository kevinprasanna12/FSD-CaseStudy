using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        public IActionResult Dashboard() => View();

        public IActionResult UpdateProfile() => View();

        public IActionResult AddRemoveCourses() => View();

        public IActionResult AddRemoveTrainers() => View();

        public IActionResult AddRemoveLearners() => View();

        public IActionResult Logout() => RedirectToAction("Index", "Home");
    }
}
