using Microsoft.EntityFrameworkCore;
using ContactDomain.Entity;

namespace Contact.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ContactEntity> Contacts { get; set; }
    }
}
