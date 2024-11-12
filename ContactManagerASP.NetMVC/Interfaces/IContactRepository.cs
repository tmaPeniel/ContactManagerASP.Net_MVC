using ContactManagerASP.NetMVC.Models;

namespace ContactManagerASP.NetMVC.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetByIdAsync(int id);

        Task<List<Contact>> GetContactsByName(string name);
        Task<List<Contact>> GetContactsByMail(string mail);

        bool Add (Contact contact);
        bool Update (Contact contact);
        bool Delete (Contact contact);
        bool Save();

    }
}
