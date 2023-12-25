using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class RentalController : ApiController
    {
        private readonly ApplicationDbContextModels _context;
        public RentalController()
        {
            _context = new ApplicationDbContextModels();
        }

        [HttpPost]
        public IHttpActionResult NewRentals(RentalDto rental)
        {
            // 不需要在此处做判断
            // if (rental.BookIds.Count == 0)
            // {
            //     return BadRequest("没有图书可供借阅！");
            // }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);
            // if (customer == null)
            // {
            //     return BadRequest("用户无效！");
            // }
            var books = _context.Books.Where(b => rental.BookIds.Contains(b.Id)).ToList();
            if (books.Count != rental.BookIds.Count)
            {
                return BadRequest("图书列表超限！");
            }

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                {
                    return BadRequest("图书库存不足！");
                }
                book.NumberAvailable--;
                var newRental = new RentalViewModels()
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(newRental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
