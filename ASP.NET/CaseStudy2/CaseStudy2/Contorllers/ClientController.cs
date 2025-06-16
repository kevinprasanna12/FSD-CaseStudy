using CaseStudy2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy2.Contorllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        static List<ClientInfo> clients = new List<ClientInfo>();

        [Route("ShowAllClientDetails")]
        public ActionResult ShowAllClientDetails()
        {
            return View(clients);
        }

        [Route("GetDetailsByClientId/{id}")]
        public ActionResult GetDetailsByClientId(int id)
        {
            var client = clients.FirstOrDefault(c => c.ClientId == id);
            return View("ViewClientDetails",client);
        }

        [Route("GetDetailsByCompanyName/{name}")]
        public ActionResult GetDetailsByCompanyName(string name)
        {
            var client = clients.FirstOrDefault(c => c.CompanyName.ToLower() == name.ToLower());
            return View("ViewClientDetails", client);
        }

        [Route("GetDetailsByEmail/{email}")]
        public ActionResult GetDetailsByEmail(string email)
        {
            var client = clients.FirstOrDefault(c => c.Email.ToLower() == email.ToLower());
            return View("ViewClientDetails", client);
        }

        [Route("GetDetailsByCategory/{category}")]
        public ActionResult GetDetailsByCategory(string category)
        {
            var client = clients.FirstOrDefault(c => c.Category.ToLower() == category.ToLower());
            return View("ViewClientDetails", client);
        }

        [Route("GetDetailsByStandard/{standard}")]
        public ActionResult GetDetailsByStandard(string standard)
        {
            var client = clients.FirstOrDefault(c => c.Standard.ToLower() == standard.ToLower());
            return View("ViewClientDetails", client);
        }

        [HttpGet]
        [Route("AddClient")]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [Route("AddClient")]
        public ActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToAction("ShowAllClientDetails");
        }
    }
}
