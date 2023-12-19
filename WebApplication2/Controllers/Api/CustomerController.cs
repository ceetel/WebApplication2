using AutoMapper;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<CustomerModels,CustomerDto>);
        }
        // GET /api/customers/1
        [HttpGet]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            // source => distinct
            return Mapper.Map<CustomerModels, CustomerDto>(customer);
        }
        // POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, CustomerModels>(customerDto);
            // 所以在这一步customer.Id就已经生成了
            // （在执行 _context.Customers.Add(customer);
            // 之后，customer 对象的 Id 属性应该包含数据库生成的唯一标识符
            // （如果数据库表配置为自动生成主键））
            _context.Customers.Add(customer);
            _context.SaveChanges();
            // customer.Id是由数据库生成的，所以需要回传。
            customerDto.Id = customer.Id;

            return customerDto;
        }
        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<CustomerDto, CustomerModels>(customerDto, customerInDb);
            customerInDb.Name = customerDto.Name;
            customerInDb.PhoneNumber = customerDto.PhoneNumber;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            _context.SaveChanges();
        }
        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
