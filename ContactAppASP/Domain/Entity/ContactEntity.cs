namespace ContactDomain.Entity
{
    public class ContactEntity
    {
        /// <summary>
        /// Свойство Id контакта.
        /// </summary>
        public long Id { get; set; }

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
    }
}
