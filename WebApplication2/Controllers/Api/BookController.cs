using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class BookController : ApiController
    {
        private readonly ApplicationDbContextModels _context;
        public BookController()
        {
            _context = new ApplicationDbContextModels();
        }

        // GET /api/book
        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            var bookDtos = _context.Books.ToList().Select(Mapper.Map<BookModels, BookDto>);
            return Ok(bookDtos);
        }
        // GET /api/book/1
        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<BookModels, BookDto>(book));
        }

        // POST /api/book
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = Mapper.Map<BookDto, BookModels>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }
        // PUT /api/book/1
        [HttpPut]
        public void UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var bookInDb = _context.Books.FirstOrDefault(b => b.Id == id)
                           ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            // use the map method assign bookInDb from property of bookDto 
            Mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();
        }
        //DELETE /api/book/1
        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.FirstOrDefault(c => c.Id == id)
                           ?? throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
        }
    }
}
