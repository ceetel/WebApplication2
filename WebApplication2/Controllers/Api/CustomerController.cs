using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContextModels _context;
        public CustomerController()
        {
            _context = new ApplicationDbContextModels();
        }

        // GET /api/customer
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<CustomerModels, CustomerDto>);
            return Ok(customerDtos);
        }
        // GET /api/customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            // source => distinct
            return Ok(Mapper.Map<CustomerModels, CustomerDto>(customer));
        }
        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, CustomerModels>(customerDto);
            // 所以在这一步customer.Id就已经生成了
            // （在执行 _context.Customers.Add(customer);
            // 之后，customer 对象的 Id 属性应该包含数据库生成的唯一标识符
            // （如果数据库表配置为自动生成主键））
            _context.Customers.Add(customer);
            _context.SaveChanges();
            // customer.Id是由数据库生成的，所以需要回传。
            customerDto.Id = customer.Id;

            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        // PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id) 
                               ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            //Mapper.Map<CustomerDto, CustomerModels>(customerDto, customerInDb); is same with behind one.
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }
        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
