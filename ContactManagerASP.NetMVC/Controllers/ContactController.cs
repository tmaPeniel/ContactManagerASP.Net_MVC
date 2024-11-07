using ContactManagerASP.NetMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerASP.NetMVC.Controllers
{
    public class ContactController : Controller
    {
        private List<Contact> Contacts { get; set; }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }

    
}
