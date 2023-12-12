﻿using Contact.Domain.Entity;

namespace Contact.DAL.Repository
{
    /// <summary>
    /// Обобщенный интерфейс взаимодействия с базой данных.
    /// </summary>
    /// <typeparam name="T">Тип данных параметра.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Получение списка контактов.
        /// </summary>
        /// <returns>Возвращает список контактов в базе данных.</returns>
        IEnumerable<T> GetContacts();

        /// <summary>
        /// Получение контакта по ID.
        /// </summary>
        /// <param name="id">Id контакта.</param>
        /// <returns>Возвращает контакт типа <see cref="ContactEntity"/>.</returns>
        T GetContact(int id);

        /// <summary>
        /// Создание контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        void Create(ContactEntity contact);

        /// <summary>
        /// Изменение контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        void Update(ContactEntity contact, int id);

        /// <summary>
        /// Удаление контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе данных.</param>
        void Delete(int id);
    }
}
