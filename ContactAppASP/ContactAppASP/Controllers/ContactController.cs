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
        private AppDbContext Db { get; set; }

        public ContactController(AppDbContext db)
        {
            Db = db;
        }

        /// <summary>
        /// Запрос главной страницы.
        /// </summary>
        /// <returns>Возвращает главную страница.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await Db.Contacts.ToListAsync());
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
            var contact = Db.Contacts.FirstOrDefault(x => x.Id == id);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ViewData["photo"] = "data:image/png;base64,"
                    + Convert.ToBase64String(contact.Photo);
            ContactService.SelectedId = id;
            return View("Index", await Db.Contacts.ToListAsync());
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var contact = Db.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null) 
            {
                Db.Contacts.Remove(contact);
                Db.SaveChanges();
            }
            ContactService.SelectedId = -1;
            return View("Index", await Db.Contacts.ToListAsync());
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Переданный id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public IActionResult EditContact()
        {
            var contact = Db.Contacts.FirstOrDefault(x => x.Id == ContactService.SelectedId);
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

        /// <summary>
        /// Присваивает новые значения контакту.
        /// </summary>
        /// <param name="name">Измененное имя.</param>
        /// <param name="number">Измененный номер.</param>
        /// <param name="email">Измененный Email.</param>
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
                Db.Contacts.Add(saveContact);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            var editContact = Db.Contacts.FirstOrDefault(x => x.Id == ContactService.SelectedId);
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
                Db.Contacts.Update(editContact);
                Db.SaveChanges();
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
            return RedirectToAction("Index");
        }
    }
}