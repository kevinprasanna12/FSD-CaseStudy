using Microsoft.AspNetCore.Mvc;
using CaseStudy1.Models;

namespace CaseStudy1.Controllers
{
    [Route("client")]
    public class ClientController : Controller
    {
        private static List<ClientInfo> clients = new List<ClientInfo>();

        [Route("all")]
        public ActionResult ShowAllClientDetails()
        {
            return View(clients);
        }

        [Route("details/id/{id}")]
        public ActionResult GetDetailsById(int id)
        {
            var client = clients.FirstOrDefault(c => c.ClientId == id);

            return View("client detail",client);
        }

        [Route("details/name/{name}")]
        public ActionResult GetDetailsByCompanyName(string name)
        {   
            var client = clients.FirstOrDefault(c=>c.CompanyName == name);
            return View("ClientDetail", client);
        }
        [Route("details/email/{email}")]
        public ActionResult GetDetailsByEmail(string email)
        {
            var client = clients.FirstOrDefault(c => c.Email == email);
            return View("ClientDetail", client);
        }

        [Route("details/category/{category}")]
        public ActionResult GetDetailsByCategory(string category)
        {
            var client = clients.FirstOrDefault(c => c.Category == category);
            return View("ClientDetail", client);
        }

        [Route("details/standard/{standard}")]
        public ActionResult GetDetailsByStandard(string standard)
        {
            var client = clients.FirstOrDefault(c => c.Standard == standard);
            return View("ClientDetail", client);
        }

        [Route("add")]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToAction("ShowAllClientDetails");
        }


    }
}
