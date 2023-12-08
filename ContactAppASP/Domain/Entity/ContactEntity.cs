﻿namespace Contact.Domain.Entity
{
    /// <summary>
    /// Класс представления контакта в базе данных.
    /// </summary>
    public class ContactEntity: IComparable<ContactEntity>
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

        /// <summary>
        /// Метод сравнения по полю класса <see cref= "ContactEntity"/>.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Критерий для сортировки методом Sort().</returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(ContactEntity? other)
        {
            if (other is ContactEntity)
            {
                return Name.CompareTo(other.Name);
            }
            throw new ArgumentException("Некорректное значение параметра");
        }
    }
}
