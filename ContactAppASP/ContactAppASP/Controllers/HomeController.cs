﻿using Microsoft.AspNetCore.Mvc;
using ContactAppASP.Models;
using Contact.DAL.AppDbContext;
using Microsoft.EntityFrameworkCore;
using ContactAppASP.Services;
using System;

namespace ContactAppASP.Controllers
{
    /// <summary>
    /// Главный контроллер.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Список контактов в базе.
        /// Будет заменен потом на БД.
        /// </summary>
        private List<Models.Contact> contacts = ContactList.GetList();

        private AppDbContext Db { get; set; }

        public HomeController(AppDbContext db)
        {
            Db = db;
            Console.WriteLine(db);
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
            return View("EditContact");
        }

        /// <summary>
        /// Запрос на вывод выбранного пользователем контакта.
        /// </summary>
        /// <param name="index">Переданный индекс контакта в базе.</param>
        /// <returns>Возвращает представление с информацией о контакте.</returns>
        [HttpGet]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = Db.Contacts.FirstOrDefault(x => x.Id == id);
            ViewData["name"] = contact.Name;
            ViewData["phone"] = contact.Phone;
            ViewData["email"] = contact.Email;
            ContactList.SelectedIndex = id;
            return View("Index", await Db.Contacts.ToListAsync());
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
            ContactList.SelectedIndex = -1;
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
            var selectedContact = ContactList.GetContact(ContactList.SelectedIndex);
            ViewData["name"] = selectedContact.Name;
            ViewData["phone"] = selectedContact.Phone;
            ViewData["email"] = selectedContact.Email;
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
        public IActionResult SaveEditContact(
            string name, 
            string number, 
            string email, 
            IFormFile photo)
        {
            if (ContactList.SelectedIndex < 0)
            {
                var contact = ContactService.AddContact(name, number, email, photo);
                Db.Contacts.Add(contact);
                Db.SaveChanges();
                /*var newContact = new Models.Contact(name, email, number);
                ContactList.AddToList(newContact);*/
                return RedirectToAction("Index");
            }

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
        /// <returns>Возвращает на главную страницу.</returns>
        [HttpPost]
        public IActionResult CancelAction()
        {
            return RedirectToAction("Index");
        }
    }
}