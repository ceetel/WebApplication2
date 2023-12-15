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

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}
        //// Movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Title";
        //    }
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //[Route("book/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseData(int year, int month)
        //{
        //    //if (year < 2015 || year > 2016 ) { return HttpNotFound(); };
        //    //if (month<1 || month > 12) { return HttpNotFound(); };
        //    return Content(year + "/" + month);
        //}
    }
}