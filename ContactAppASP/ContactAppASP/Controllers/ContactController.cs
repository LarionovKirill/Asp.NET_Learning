using Microsoft.AspNetCore.Mvc;
using Contact.DAL.AppDbContext;
using Microsoft.EntityFrameworkCore;
using ContactAppASP.Services;

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
        private AppDbContext _database;

        /// <summary>
        /// Конструктор контроллера <see cref="ContactController"/>.
        /// </summary>
        /// <param name="db">База данных.</param>
        public ContactController(AppDbContext db)
        {
            _database = db;
        }

        /// <summary>
        /// Запрос главной страницы.
        /// </summary>
        /// <returns>Возвращает главную страница.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _database.Contacts.ToListAsync());
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
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = _database.Contacts.FirstOrDefault(x => x.Id == id);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ViewData["photo"] = "data:image/png;base64,"
                    + Convert.ToBase64String(contact.Photo);
            ContactService.SelectedId = id;
            return View("Index", await _database.Contacts.ToListAsync());
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var contact = _database.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null) 
            {
                _database.Contacts.Remove(contact);
                _database.SaveChanges();
            }
            ContactService.SelectedId = -1;
            return View("Index", await _database.Contacts.ToListAsync());
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
                var contact = _database.Contacts.FirstOrDefault(x => x.Id == ContactService.SelectedId);
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
            IFormFile photo)
        {
            if (ContactService.SelectedId < 0)
            {
                var saveContact = ContactService.AddContact(name, number, email, photo);
                _database.Contacts.Add(saveContact);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }

            var editContact = _database.Contacts.FirstOrDefault(x => x.Id == ContactService.SelectedId);
            if (editContact != null)
            {
                editContact.Name = name;
                editContact.Phone = number;
                editContact.Email = email;
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)photo.Length);
                }
                editContact.Photo = imageData;
                _database.Contacts.Update(editContact);
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
    }
}