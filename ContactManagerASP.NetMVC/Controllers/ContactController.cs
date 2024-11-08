using ContactManagerASP.NetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.IO;
using ContactManagerASP.NetMVC.Repository;
using ContactManagerASP.NetMVC.Interfaces;
using ContactManagerASP.NetMVC.ViewModels;

namespace ContactManagerASP.NetMVC.Controllers
{
    public class ContactController : Controller
    {

        // En .Net 8 on passe par l'interface plutot que la classe
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
        

        /* Pour edit on recupere le contact par son ID, que l'on convertit en VM pour faire la modification*/
        public async Task<IActionResult> Edit (int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if(contact==null) return View("Error");
            var contactVM = new EditContactViewModel
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Email = contact.Email,
                Numero = contact.Numero
            };

            return View(contactVM);
        }

        /* Pour valider la modification on fait un post avec lequel on récupere le viewModel et l'ID que l'on 
         * convertit en Modele pour sauvegarder dans la bdd
         */
        [HttpPost]
        public async Task<IActionResult>Edit(int id, EditContactViewModel contactVm)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", contactVm);
            };

            //On récupère le contact
            var contact = new Contact
            {
                Id = id,
                Name = contactVm.Name,
                Surname = contactVm.Surname,
                Email = contactVm.Email,
                Numero = contactVm.Numero
            };
            
            _contactRepository.Update(contact);
            return RedirectToAction("IndexContact");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contactDetail = await _contactRepository.GetByIdAsync(id);
            if (contactDetail == null) return View("Error");
            return View(contactDetail);
        }

        //ActionName ici c'est Delete et non DeleteContact pour que le boutton de confirmation cible cette action pour faire un post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null) return View("Error");

            _contactRepository.Delete(contact);

            return RedirectToAction("IndexContact");
        }
    }   
}
