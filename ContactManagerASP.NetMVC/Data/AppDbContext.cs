using ContactManagerASP.NetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerASP.NetMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Ici on liste les classe que l'on veut mapper à la BDD
        public DbSet<Contact> Contacts { get; set; }
    }
}
