using Contact.Domain.Entity;

namespace ContactAppASP.Services
{
    public static class ContactService
    {
        /// <summary>
        /// Выбранный Id.
        /// </summary>
        public static int SelectedId { get; set; }

        /// <summary>
        /// Метод создания контакта для передачи его в базу данных.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="phone">Номер телефона контакта.</param>
        /// <param name="email">Email контатка.</param>
        /// <param name="photo">Фото контакта.</param>
        /// <returns>Возвращает контакт типа <see cref="ContactEntity"/>.</returns>
        public static ContactEntity AddContact(
            string name,
            string phone, 
            string email, 
            IFormFile photo)
        {
            var contact = new ContactEntity { Name = name, Phone = phone, Email = email };
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(photo.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)photo.Length);
            }
            contact.Photo = imageData;
            return contact;
        }
    }
}
