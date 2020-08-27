using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            repository.CreateBook(book);
            TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены", book.Name);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int bookId)
        {          
                Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
                repository.DeleteBook(book);
                TempData["message"] = string.Format("Книга \"{0}\" удалена.", book.Name);

            return RedirectToAction("Index");          
        }
    }
}