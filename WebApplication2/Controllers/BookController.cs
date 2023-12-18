using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }
        // 释放资源
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult New()
        {
            var viewModel = new BookFormViewModels
            {
                Book = new BookModels(),
            };
            return View("BookForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookModels book)
        {
            // Check if the data not match the model role.
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModels
                {
                    Book = book,
                };
                return View("BookForm", viewModel);
            }
            // New Book
            if (book.Id == 0)
            {
                // Check if the Book.Title && Book.Author is already in use
                if (_context.Books.FirstOrDefault(b => b.Title == book.Title && b.Author == book.Author) != null)
                {
                    ViewBag.ErrorMessage = "The user already exists.";
                    var viewModel = new BookFormViewModels
                    {
                        Book = book,
                    };
                    return View("BookForm", viewModel);
                }
                _context.Books.Add(book);
            }
            // Edit Book
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);
                bookInDb.Author = book.Author;
                bookInDb.Description = book.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public ViewResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var viewModel = new BookFormViewModels
            {
                Book = book,
                //MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("BookForm", viewModel);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            // Retrieve the book from the database
            var book = _context.Books.Find(id);

            // Check if the book exists
            if (book == null)
            {
                return HttpNotFound();
            }

            // Remove the book from the context and save changes
            _context.Books.Remove(book);
            _context.SaveChanges();

            // Redirect to the index action (or any other desired action)
            return RedirectToAction("Index", "Book");
        }
    }
}