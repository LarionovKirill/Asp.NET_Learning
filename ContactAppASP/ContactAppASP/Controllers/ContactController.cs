﻿using Microsoft.AspNetCore.Mvc;
using ContactAppASP.Services;
using Contact.DAL.Repository;

namespace ContactAppASP.Controllers
{
    /// <summary>
    /// Главный контроллер.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Репозиторий.
        /// </summary>
        private IRepository _contactRepository;

        /// <summary>
        /// Конструктор контроллера <see cref="ContactController"/>.
        /// </summary>
        /// <param name="db">База данных.</param>
        public ContactController(IRepository db)
        {
            _contactRepository = db;
        }

        /// <summary>
        /// Запрос главной страницы.
        /// </summary>
        /// <returns>Возвращает главную страница.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(ContactService.PrepareContactList(_contactRepository));
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
            var contact = _contactRepository.GetContact(id);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ViewData["photo"] = "data:image/png;base64,"
                    + Convert.ToBase64String(contact.Photo);
            ContactService.SelectedId = id;
            var viewList = ContactService.PrepareContactList(_contactRepository);
            return View("Index", viewList);
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _contactRepository.Delete(id);
            ContactService.SelectedId = -1;
            var viewList = ContactService.PrepareContactList(_contactRepository);
            return View("Index", viewList);
        }

        /// <summary>
        /// Запрос на удаление выбранного пользователем контакта.
        /// </summary>
        /// <param name="id">Переданный id контакта в базе.</param>
        /// <returns>Возвращает представление с удаленным контактом.</returns>
        [HttpGet]
        public IActionResult EditContact()
        {
            if (ContactService.SelectedId <= 0)
            {
                return RedirectToAction("Index");
            }
            var contact = _contactRepository.GetContact(ContactService.SelectedId);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ViewData["photo"] = "data:image/png;base64,"
                + Convert.ToBase64String(contact.Photo);
            return View("AddEditContact");
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
        public async Task<IActionResult> SaveEditContact(
            string name, 
            string number, 
            string email, 
            IFormFile? photo)
        {
            if (ContactService.SelectedId < 0)
            {
                var saveContact = ContactService.AddContact(name, number, email, photo);
                await _contactRepository.Create(saveContact);
                return RedirectToAction("Index");
            }

            var editContact = _contactRepository.GetContact(ContactService.SelectedId);
            editContact.Name= name;
            editContact.Phone= number;
            editContact.Email= email;
            editContact.Id = ContactService.SelectedId;
            if (photo != null)
            {
                editContact.Photo = ContactService.ConvertPhotoToBytes(photo);
            }
            _contactRepository.Update(editContact);
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

        /// <summary>
        /// Поиска контактов по переданной маске.
        /// </summary>
        /// <param name="mask">Маска имени.</param>
        /// <returns>Возвращает на главную страницу со списков контактов,
        /// подходящих по маску.</returns>
        [HttpGet]
        public IActionResult FindContacts(string mask)
        {
            if (mask == null)
            {
                ContactService.Mask = string.Empty;
                ContactService.FirstLetter = string.Empty;
                return RedirectToAction("Index");
            }
            ContactService.Mask = mask;
            var viewList = ContactService.PrepareContactList(_contactRepository);
            return View("Index", viewList);
        }

        /// <summary>
        /// Поиск контактов по первой букве контакта.
        /// </summary>
        /// <param name="letter">Начальная буква.</param>
        /// <returns>Возвращает на главную страницу со списком контактов,
        /// подходящих под первую букву.</returns>
        [HttpGet]
        public IActionResult FindByFirstLetter(string letter)
        {
            if (letter.Length==1)
            {
                ContactService.Mask = string.Empty;
                ContactService.FirstLetter = letter.ToLower();
                return RedirectToAction("Index");
            }
            ContactService.Mask = string.Empty;
            ContactService.FirstLetter = string.Empty;
            return RedirectToAction("Index");
        }
    }
}