namespace ContactAppASP.ContactsFactory
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Имя контака.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Электронная почта контакта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Contact"/>
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
