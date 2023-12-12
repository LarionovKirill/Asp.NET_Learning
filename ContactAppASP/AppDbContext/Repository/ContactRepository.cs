using Contact.Domain.Entity;

namespace Contact.DAL.Repository
{
    /// <summary>
    /// Интерфейс для работы с объектами контактов в базе данных.
    /// </summary>
    public class ContactRepository : IRepository<ContactEntity>
    {
        /// <summary>
        /// База данных.
        /// </summary>
        private AppDbContext.AppDbContext _database;

        /// <summary>
        /// Конструктор класса <see cref="ContactRepository"/>.
        /// </summary>
        /// <param name="db">База данных.</param>
        public ContactRepository(AppDbContext.AppDbContext db)
        {
            _database = db;
        }

        /// <summary>
        /// Создание контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        public async void Create(ContactEntity contact)
        {
            _database.Contacts.AddAsync(contact);
            _database.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе данных.</param>
        public async void Delete(int id)
        {
            var contact = GetContact(id);
            _database.Contacts.Remove(contact);
            _database.SaveChangesAsync();
        }

        /// <summary>
        /// Получение контакта по Id.
        /// </summary>
        /// <param name="id">Id контакта.</param>
        /// <returns>Возвращает контакт типа <see cref="ContactEntity"/>.</returns>
        public ContactEntity GetContact(int id)
        {
            return _database.Contacts.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение списка контактов.
        /// </summary>
        /// <returns>Возвращает список контактов в базе данных.</returns>
        public IEnumerable<ContactEntity> GetContacts()
        {
            return _database.Contacts;
        }

        /// <summary>
        /// Изменение контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        public async void Update(ContactEntity contact, int id)
        {
            var editContact = _database.Contacts.FirstOrDefault(x => x.Id == id);
            editContact.Clone(contact);
            _database.SaveChangesAsync();
        }
    }
}
