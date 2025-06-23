// Controllers/TrainerController.cs
using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("[controller]/[action]")]
    public class TrainerController : Controller
    {
        public IActionResult Dashboard() => View();

        public IActionResult UpdateProfile() => View();

        public IActionResult AddRemoveContent() => View();

        public IActionResult Logout() => RedirectToAction("Index", "Home");
    }
}
