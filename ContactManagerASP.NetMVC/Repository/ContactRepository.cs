using ContactManagerASP.NetMVC.Data;
using ContactManagerASP.NetMVC.Interfaces;
using ContactManagerASP.NetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerASP.NetMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        // pour relier notre app à la BDD
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;       
        }


        public bool Add(Contact contact)
        {
            _context.Add(contact);
            return Save();
        }

        public bool Delete(Contact contact)
        {
            _context.Remove(contact);
            return Save();
        }

        //Lorsque tu veux lister tous les éléments sans chercher. Comme en SQL
        //Pourquoi async ? 
        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x=> x.Id == id);
        }

        //Lorsque tu veux lister le resultat d'une recherche on utilise where, comme en sql
        public async Task<List<Contact>> GetContactsByMail(string mail)
        {
           return await _context.Contacts.Where(x => x.Email == mail).ToListAsync();
        }

        public async Task<List<Contact>> GetContactsByName(string name)
        {
            return await _context.Contacts.Where(x=> x.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Contact contact)
        {
            _context.Update(contact);
            return Save();
        }
    }
}
