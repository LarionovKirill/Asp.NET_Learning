namespace ContactAppASP.ContactsFactory
{
    public static class ContactList
    {
        public static List<Contact> Contacts { get; set; } = new List<Contact>();


        public static List<Contact> GetList()
        {
             return Contacts;
        }

        public static List<Contact> AddToList(Contact contact)
        {
            Contacts.Add(contact);
            return Contacts;
        }

        public static List<Contact> RemoveInList(int index) 
        {
            Contacts.RemoveAt(index);
            return Contacts;
        }

        public static Contact ShowContact(int index)
        {
            return Contacts[index];
        }
    }
}
