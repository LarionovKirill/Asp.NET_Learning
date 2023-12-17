using Contact.Domain.Entity;

namespace Contact.DAL.Repository
{
    /// <summary>
    /// Интерфейс для работы с объектами контактов в базе данных.
    /// </summary>
    public class ContactRepository : IRepository
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
        /// Получение списка контактов.
        /// </summary>
        /// <returns>Возвращает список контактов в базе данных.</returns>
        public IEnumerable<ContactEntity> GetContacts()
        {
            return _database.Contacts;
        }

        /// <summary>
        /// Нахождение контактов по переданной маске.
        /// </summary>
        /// <param name="mask">Маска имени контакта.</param>
        /// <returns></returns>
        public IEnumerable<ContactEntity> FindContacts(string mask)
        {
            mask = mask.ToLower();
            var foundСontacts = _database.Contacts.Where(x => x.Name.ToLower().Contains(mask));
            return foundСontacts;
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
        /// Создание контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        public async Task Create(ContactEntity contact)
        {
            await _database.Contacts.AddAsync(contact);
            await _database.SaveChangesAsync();
        }

        /// <summary>
        /// Изменение контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        public async Task Update(ContactEntity contact, int id)
        {
            var editContact = GetContact(id);
            editContact.Clone(contact);
            await _database.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе данных.</param>
        public async Task Delete(int id)
        {
            var contact = GetContact(id);
            _database.Contacts.Remove(contact);
            await _database.SaveChangesAsync();
        }
    }
}
