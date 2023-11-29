using Microsoft.EntityFrameworkCore;
using Contact.Domain.Entity;

namespace Contact.DAL.AppDbContext
{
    /// <summary>
    /// Класс подключения к базе данных.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}