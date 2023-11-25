namespace ContactAppASP.Models
{
    /// <summary>
    /// Список контактов.
    /// Временнная замена базы данных.
    /// </summary>
    public static class ContactList
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        private static List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Хранит выбранный индекс контакта.
        /// </summary>
        public static int SelectedIndex { get; set; }

        /// <summary>
        /// Метод передачи списка.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public static List<Contact> GetList()
        {
            return Contacts;
        }

        /// <summary>
        /// Добавления контакта в список.
        /// </summary>
        /// <param name="contact">Новый контакт.</param>
        /// <returns>Новый список.</returns>
        public static List<Contact> AddToList(Contact contact)
        {
            Contacts.Add(contact);
            return Contacts;
        }

        /// <summary>
        /// Удаление из списка.
        /// </summary>
        /// <param name="index">Индекс контакта.</param>
        /// <returns>Обновленный список.</returns>
        public static List<Contact> RemoveInList(int index)
        {
            Contacts.RemoveAt(index);
            return Contacts;
        }

        /// <summary>
        /// Передача одного контакта.
        /// </summary>
        /// <param name="index">Индекс контакта.</param>
        /// <returns>Выбранный контакт.</returns>
        public static Contact GetContact(int index)
        {
            return Contacts[index];
        }
    }
}
