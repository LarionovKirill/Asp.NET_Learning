using Contact.Domain.Entity;

namespace ContactAppASP.Services
{
    public static class ContactService
    {
        /// <summary>
        /// Путь к фото по умолчанию.
        /// </summary>
        private const string Path = "wwwroot/images/Empty_User_818x500.png";

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
            var contact = new ContactEntity(name, phone, email);
            if (photo != null)
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)photo.Length);
                }
                contact.Photo = imageData;
            }
            else
            {
                var imageData = File.ReadAllBytes(Path);
                contact.Photo = imageData;
            }
            return contact;
        }
    }
}
