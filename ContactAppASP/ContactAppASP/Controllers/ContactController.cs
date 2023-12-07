using Microsoft.AspNetCore.Mvc;
using Contact.DAL.AppDbContext;
using Microsoft.EntityFrameworkCore;
using ContactAppASP.Services;
using Contact.DAL.Repository;
using Contact.Domain.Entity;

namespace ContactAppASP.Controllers
{
    /// <summary>
    /// Главный контроллер.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// База данных.
        /// </summary>
        private IRepository<ContactEntity> _database;

        /// <summary>
        /// Конструктор контроллера <see cref="ContactController"/>.
        /// </summary>
        /// <param name="db">База данных.</param>
        public ContactController(AppDbContext db)
        {
            _database = new SQLContactRepository(db);
        }

        /// <summary>
        /// Запрос главной страницы.
        /// </summary>
        /// <returns>Возвращает главную страница.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(_database.GetContacts());
        }

        /// <summary>
        /// Запускает представление создания контакта.
        /// </summary>
        /// <returns>Возвращает форму создания контакта.</returns>
        [HttpGet]
        public IActionResult AddContact()
        {
            ContactService.SelectedId = -1;
            return View("AddEditContact");
        }

        /// <summary>
        /// Запрос на вывод выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Переданный id контакта в базе.</param>
        /// <returns>Возвращает представление с информацией о контакте.</returns>
        [HttpGet]
        public IActionResult GetContact(int id)
        {
            var contact = _database.GetContact(id);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ViewData["photo"] = "data:image/png;base64,"
                    + Convert.ToBase64String(contact.Photo);
            ContactService.SelectedId = id;
            return View("Index", _database.GetContacts());
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public IActionResult RemoveContact(int id)
        {
            _database.Delete(id);
            ContactService.SelectedId = -1;
            return View("Index", _database.GetContacts());
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Переданный id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public IActionResult EditContact()
        {
            if (ContactService.SelectedId > 0)
            {
                var contact = _database.GetContact(ContactService.SelectedId);
                if (contact != null)
                {
                    ViewData["name"] = contact.Name;
                    ViewData["phone"] = contact.Phone;
                    ViewData["email"] = contact.Email;
                    ViewData["photo"] = "data:image/png;base64,"
                        + Convert.ToBase64String(contact.Photo);
                }
                return View("AddEditContact");
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Присваивает новые значения контакту.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="number">Номер.</param>
        /// <param name="email">Email.</param>
        /// <param name="photo">Фото.</param>
        /// <returns>Возвращает на главную страницу с исправленным контактом.</returns>
        [HttpPost]
        public IActionResult SaveEditContact(
            string name, 
            string number, 
            string email, 
            IFormFile photo = null)
        {
            if (ContactService.SelectedId < 0)
            {
                var saveContact = ContactService.AddContact(name, number, email, photo);
                _database.Create(saveContact);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }

            var editContact = _database.GetContact(ContactService.SelectedId);
            if (editContact != null)
            {
                byte[] copyPhoto = editContact.Photo;
                editContact = ContactService.AddContact(name, number, email, photo);
                if (copyPhoto != editContact.Photo)
                {
                    editContact.Photo = copyPhoto;
                }
                _database.Update(editContact, ContactService.SelectedId);
                _database.SaveChanges();
            }
            ContactService.SelectedId = -1;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Отмена действия с контактом.
        /// </summary>
        /// <returns>Возвращает на главную страницу.</returns>
        [HttpPost]
        public IActionResult CancelAction()
        {
            ContactService.SelectedId = -1;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _database.Dispose();
            base.Dispose(disposing);
        }
    }
}