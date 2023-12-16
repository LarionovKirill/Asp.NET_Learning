namespace Contact.Domain.Entity
{
    /// <summary>
    /// Класс представления контакта в базе данных.
    /// </summary>
    public class ContactEntity : ICloneable
    {
        /// <summary>
        /// Id контакта.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя контакта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email контакта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номера телефона контакта.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Фото человека в контактах.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Констуктор класса <see cref="ContactEntity"/>.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="email">Email контакта.</param>
        /// <param name="phone">Телефон контакта.</param>
        /// <param name="photo">Фото контакта.</param>
        public ContactEntity(string name, string email, string phone, byte[] photo)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Photo = photo;
        }

        /// <summary>
        /// Констуктор класса <see cref="ContactEntity"/>.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="email">Email контакта.</param>
        /// <param name="phone">Телефон контакта.</param>
        public ContactEntity(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        /// <summary>
        /// Копирует значения переданного контакта.
        /// </summary>
        /// <param name="contact">Переданный контакт.</param>
        public void Clone(ContactEntity contact)
        {
            Name = contact.Name;
            Email = contact.Email;
            Phone = contact.Phone;
            Photo = contact.Photo;
        }

        public object Clone()
        {
            return new ContactEntity(Name, Email, Phone, Photo);
        }
    }
}
