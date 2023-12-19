using HH_XygPeixun;
using NPOI.SS.Formula;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public BookController()
        {
            _context = new ApplicationDbContext();
        }
        // release resource
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
                    // reset form
                    var viewModel = new BookFormViewModels
                    {
                        Book = book,
                    };
                    return View("BookForm", viewModel);
                }
                // legacy code: add
                string sql = "INSERT INTO BookModels (Title, Author, Description) VALUES (@Title, @Author, @Description)";
                SqlParameter[] sp = {
                    new SqlParameter("@Title", book.Title),
                    new SqlParameter("@Author", book.Author),
                    new SqlParameter("@Description", book.Description)
                };
                RY_SQLHelper.getExecuteNonQuery(strConn, sql, sp);
                // MVC code
                //_context.Books.Add(book);
            }
            // Edit Book
            else
            {
                // legacy code: update
                string sql = "UPDATE BookModels SET Title = @Title, Author = @Author, Description = @Description where Id=@Id";
                SqlParameter[] sp = { 
                    new SqlParameter("@Id", book.Id.ToString()),
                    new SqlParameter("@Title", book.Title),
                    new SqlParameter("@Author", book.Author),
                    new SqlParameter("@Description", book.Description)
                };
                RY_SQLHelper.getExecuteNonQuery(strConn, sql, sp);
                //var bookInDb = _context.Books.Single(c => c.Id == book.Id);
                //bookInDb.Author = book.Author;
                //bookInDb.Description = book.Description;
            }
            //_context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public ViewResult Index()
        {
            // legacy code: query
            string sql = "SELECT * FROM BookModels";
            DataTable dataTable = RY_SQLHelper.getDataTable(strConn, 0, sql);
            List<BookModels> books = dataTable.AsEnumerable()
            .Select(row => new BookModels
            {
                Id = Convert.ToInt32(row["Id"]),
                Title = Convert.ToString(row["Title"]),
                Author = Convert.ToString(row["Author"]),
                Description = Convert.ToString(row["Description"]),
            }).ToList();
            return View(books);

            // MVC code
            //var books = _context.Books.ToList();
            //return View(books);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            //legacy code: query
            string sql = $"SELECT * FROM BookModels WHERE ID = {id}";
            DataTable dataTable = RY_SQLHelper.getDataTable(strConn, 0, sql);
            List<BookModels> books = dataTable.AsEnumerable()
            .Select(row => new BookModels
            {
                Id = Convert.ToInt32(row["Id"]),
                Title = Convert.ToString(row["Title"]),
                Author = Convert.ToString(row["Author"]),
                Description = Convert.ToString(row["Description"]),
            }).ToList();
            if (books.Count == 1)
            {
                var bookModel = books[0];
                var viewModel = new BookFormViewModels
                {
                    Book = bookModel
                };
                return View("BookForm", viewModel);

            }
            else
            {
                ViewBag.ErrorMessage = $"ID: {id},有毛病";
                return View();
            };

            // MVC code
            //var book = _context.Books.SingleOrDefault(b => b.Id == id);
            //if (book == null)
            //{
            //    return HttpNotFound();
            //}
            //var viewModel = new BookFormViewModels
            //{
            //    Book = book,
            //};
            //return View("BookForm", viewModel);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            // legacy code: delete
            string sql = "DELETE FROM BookModels where Id=@Id";
            SqlParameter[] sp = { new SqlParameter("@Id", id.ToString()) };
            RY_SQLHelper.getExecuteNonQuery(strConn, sql, sp);
            return RedirectToAction("Index", "Book");
            // MVC code
            //// Find out the book from the database
            //var book = _context.Books.Find(id);

            //// Check if the book exists
            //if (book == null)
            //{
            //    return HttpNotFound();
            //}

            //// Remove the book from the context and save changes
            //_context.Books.Remove(book);
            //_context.SaveChanges();

            //// Redirect to the index action (or any other desired action)
            //return RedirectToAction("Index", "Book");
        }

    }
}