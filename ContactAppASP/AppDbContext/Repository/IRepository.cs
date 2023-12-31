﻿using Contact.Domain.Entity;

namespace Contact.DAL.Repository
{
    /// <summary>
    /// Обобщенный интерфейс взаимодействия с базой данных.
    /// </summary>
    /// <typeparam name="T">Тип данных параметра.</typeparam>
    public interface IRepository
    {
        /// <summary>
        /// Получение списка контактов.
        /// </summary>
        /// <returns>Возвращает список контактов в базе данных.</returns>
        IEnumerable<ContactEntity> GetContacts();

        /// <summary>
        /// Получение контакта по ID.
        /// </summary>
        /// <param name="id">Id контакта.</param>
        /// <returns>Возвращает контакт типа <see cref="ContactEntity"/>.</returns>
        ContactEntity GetContact(int id);

        /// <summary>
        /// Создание контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        Task Create(ContactEntity contact);

        /// <summary>
        /// Изменение контакта.
        /// </summary>
        /// <param name="contact">Контакт типа <see cref="ContactEntity"/>.</param>
        void Update(ContactEntity contact);

        /// <summary>
        /// Удаление контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе данных.</param>
        Task Delete(int id);

        /// <summary>
        /// Поиск контакта по введенной маске имени.
        /// </summary>
        /// <param name="mask">Маска имени.</param>
        /// <returns>Список контактов, с совпадающей маской в имени.</returns>
        public IEnumerable<ContactEntity> FindContacts(string mask);
    }
}
