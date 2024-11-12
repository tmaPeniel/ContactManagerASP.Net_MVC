using ContactManagerASP.NetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.IO;
using ContactManagerASP.NetMVC.Repository;
using ContactManagerASP.NetMVC.Interfaces;

namespace ContactManagerASP.NetMVC.Controllers
{
    public class ContactController : Controller
    {

        // En .Net 8 on utilise l'interface plutot que la classe
        //private readonly ContactRepository _contactRepository; (Non)
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IActionResult> IndexContact()
        {
            List<Contact> contact = await _contactRepository.GetAll();
            return View(contact);
        }

        public async Task<IActionResult> About(int id)
        {  
            var contact = await _contactRepository.GetByIdAsync(id);
            return View(contact); 
        }

        // Creer un contact: Affichage de la page Create
        public IActionResult Create()
        {
            return View();
        }

        //Creer un contact : Validation et sauvegarde du formulaire
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            //ModelState : Les informations saisi corresponde au modele
            if (!ModelState.IsValid) //Verifie si les informations du formulaire ne sont pas valide
            {
                return View(contact);
            }
            //Si les infos du formulaire sont valides alors il sauvegarde dans la BDD
            _contactRepository.Add(contact);
            return RedirectToAction("IndexContact");
        }
        


    }

    
}
