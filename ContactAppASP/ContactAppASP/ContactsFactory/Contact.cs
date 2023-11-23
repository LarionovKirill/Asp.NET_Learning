namespace ContactAppASP.ContactsFactory
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Свойство имени в контакте.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство Email в контакте.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Свойство номера телефона в контакте.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Contact()
        {
            
        }

        /// <summary>
        /// Конструктор класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="email">Email контакта.</param>
        /// <param name="phone">Номер контакта.</param>
        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
