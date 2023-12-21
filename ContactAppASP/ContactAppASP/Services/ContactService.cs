using Contact.Domain.Entity;

namespace ContactAppASP.Services
{
    /// <summary>
    /// Сервисный класс для хранения Id и создания контакта.
    /// </summary>
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
            var contact = new ContactEntity{Name = name, Phone = phone, Email=email};
            byte[] imageData;
            if (photo != null)
            {
                contact.Photo = ConvertPhotoToBytes(photo);
                return contact;
            }
            imageData = File.ReadAllBytes(Path);
            contact.Photo = imageData;
            return contact;
        }

        /// <summary>
        /// Метод конвертирует переданное фото в массив байт.
        /// </summary>
        /// <param name="photo">Фото.</param>
        /// <returns>Фото в виде массива байт.</returns>
        public static byte[] ConvertPhotoToBytes(IFormFile photo)
        {
            using var memoryStream = new MemoryStream();
            photo.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
