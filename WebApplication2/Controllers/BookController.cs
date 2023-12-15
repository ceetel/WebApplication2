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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Book/Random
        public ActionResult Random()
        {
            var book = new BookModels() { Title = "Asp.NET Framework MVC从入门到入土" };
            var customers = new List<CustomerModels>
            {
                new CustomerModels { Name = "Customer 1"},
                new CustomerModels { Name = "Customer 2"}

            };
            var viewModel = new RandomBookViewModels()
            {
                Book = book,
                Custormers = customers
            };
            //var viewModel = new BookViewModels();
            //ViewData["Title"] = book; // 因为一些灵活性问题，取而代之的是ViewBag
            //ViewBag.Book = book;
            return View(viewModel);
        }
    }
}