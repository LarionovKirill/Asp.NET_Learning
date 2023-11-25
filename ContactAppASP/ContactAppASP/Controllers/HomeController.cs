using Microsoft.AspNetCore.Mvc;
using ContactAppASP.Models;

namespace ContactAppASP.Controllers
{
    /// <summary>
    /// Главнконтроллер.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Список контактов в базе.
        /// Будет заменен потом на БД.
        /// </summary>
        private List<Models.Contact> contacts = ContactList.GetList();

        /// <summary>
        /// Запрос главной страницы.
        /// </summary>
        /// <returns>Возвращает главную страница.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Contacts = ContactList.GetList();
            return View();
        }

        /// <summary>
        /// Запускает представление создания контакта.
        /// </summary>
        /// <returns>Возвращает форму создания контакта.</returns>
        [HttpGet]
        public IActionResult AddContact()
        {
            return View("EditContact");
        }

        /// <summary>
        /// Запрос на вывод выбранного пользователем контакта.
        /// </summary>
        /// <param name="index">Переданный индекс контакта в базе.</param>
        /// <returns>Возвращает представление с информацией о контакте.</returns>
        [HttpGet]
        public IActionResult GetContact(int index)
        {
            var contact = ContactList.GetContact(index);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ViewBag.Contacts = ContactList.GetList();
            return View("Index");
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
            ViewBag.Contacts = ContactList.GetList();
            return View("Index");
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="index">Переданный индекс контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public IActionResult EditContact(int index)
        {
            var selectedContact = ContactList.GetContact(index);
            ViewData["name"] = selectedContact.Name;
            ViewData["phone"] = selectedContact.Phone;
            ViewData["email"] = selectedContact.Email;
            ContactList.SelectedIndex = index;
            return View();
        }

        /// <summary>
        /// Присваивает новые значения контакту.
        /// </summary>
        /// <param name="name">Измененное имя.</param>
        /// <param name="number">Измененный номер.</param>
        /// <param name="email">Измененный Email.</param>
        /// <returns>Возвращает на главную страницу с исправленным контактом.</returns>
        [HttpPost]
        public IActionResult SaveEditContact(string name, string number, string email)
        {
            if (ContactList.SelectedIndex < 0)
            {
                var newContact = new Models.Contact(name, email, number);
                ContactList.AddToList(newContact);
                return RedirectToAction("Index");
            }
            else
            {
                var contacts = ContactList.GetList();
                ViewBag.Index = ViewData["index"];
                contacts[ContactList.SelectedIndex].Name = name;
                contacts[ContactList.SelectedIndex].Phone = number;
                contacts[ContactList.SelectedIndex].Email = email;
                ContactList.SelectedIndex = -1;
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Отмена действия с контактом.
        /// </summary>
        /// <returns>Возвращяется на главную страницу.</returns>
        [HttpPost]
        public IActionResult CancelAction()
        {
            return RedirectToAction("Index");
        }
    }
}