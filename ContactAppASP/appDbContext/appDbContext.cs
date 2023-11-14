using Microsoft.EntityFrameworkCore;
using ContactDomain.Entity;

namespace Contact.DAL
{
    public class appDbContext : DbContext
    {

        public appDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ContactEntity> Contacts { get; set; }
    }
}
