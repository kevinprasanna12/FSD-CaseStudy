// Controllers/LearnerController.cs
using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("[controller]/[action]")]
    public class LearnerController : Controller
    {
        public IActionResult Dashboard() => View();

        public IActionResult UpdateProfile() => View();

        public IActionResult SearchContent() => View();

        public IActionResult Logout() => RedirectToAction("Index", "Home");
    }
}
