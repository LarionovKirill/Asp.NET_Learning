using Microsoft.EntityFrameworkCore;
using Contact.Domain.Entity;

namespace Contact.DAL.AppDbContext
{
    /// <summary>
    /// Класс подключения к базе данных.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Список контактов в базе данных.
        /// </summary>
        public DbSet<ContactEntity> Contacts { get; set; } = null!;

        /// <summary>
        /// Метод инициализации базы данных.
        /// </summary>
        /// <param name="options">Параметры базы данных.</param>
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}