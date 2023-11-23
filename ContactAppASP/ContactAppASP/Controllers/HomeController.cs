using Microsoft.AspNetCore.Mvc;
using ContactAppASP.ContactsFactory;

namespace ContactAppASP.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Список контактов в базе.
        /// Будет заменен потом на БД.
        /// </summary>
        List<ContactsFactory.Contact> contacts = ContactList.GetList();

        /// <summary>
        /// Запрос главной страницы.
        /// </summary>
        /// <returns>Главная страница.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(ContactList.GetList());
        }

        /// <summary>
        /// POST запрос для передачи введенных данных в базу.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="number">Номер контакта.</param>
        /// <param name="email">Email контакта.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(string name, string number, string email)
        {
            ContactsFactory.Contact newContact =
                new ContactsFactory.Contact(name, email, number);
            ContactList.AddToList(newContact);
            return View(ContactList.GetList());
        }

        /// <summary>
        /// Запускает представление создания контакта.
        /// </summary>
        /// <returns>Переходит на форму создания контакта.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Запрос на вывод выбранного пользователем контакта.
        /// </summary>
        /// <param name="index">Переданный индекс контакта в базе.</param>
        /// <returns>Возвращает представление с информацией о контакте.</returns>
        [HttpGet]
        public IActionResult ShowContact(int index)
        {
            var contact = ContactList.ShowContact(index);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            return View("Index", ContactList.GetList());
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="index">Переданный индекс контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public IActionResult RemoveContact(int index)
        {
            ContactList.RemoveInList(index);
            return View("Index", ContactList.GetList());
        }
    }
}