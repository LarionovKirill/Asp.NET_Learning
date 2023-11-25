﻿using Microsoft.AspNetCore.Mvc;
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
            return View(ContactList.GetList());
        }

        /// <summary>
        /// POST запрос для передачи введенных данных в базу.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="number">Номер контакта.</param>
        /// <param name="email">Email контакта.</param>
        /// <returns>Возвращает страницу с добавленным контактом.</returns>
        [HttpPost]
        public IActionResult AddContact(string name, string number, string email)
        {
            var newContact = new Models.Contact(name, email, number);
            ContactList.AddToList(newContact);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Запускает представление создания контакта.
        /// </summary>
        /// <returns>Возвращает форму создания контакта.</returns>
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
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
            var contacts = ContactList.GetList();
            ViewBag.Index = ViewData["index"];
            contacts[ContactList.SelectedIndex].Name = name;
            contacts[ContactList.SelectedIndex].Phone = number;
            contacts[ContactList.SelectedIndex].Email = email;
            ContactList.SelectedIndex = -1;
            return RedirectToAction("Index");
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