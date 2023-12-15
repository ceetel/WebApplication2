using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // 释放资源
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModels
            {
                MembershipTypes = membershipType
            };
            return View(viewModel);
        }
        public ViewResult Index() {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //// Test
        //private IEnumerable<CustomerModels> GetCustomers()
        //{
        //    return new List<CustomerModels>
        //    {
        //        new CustomerModels {Id = 1 , Name = "John Smith"},
        //        new CustomerModels {Id = 2 , Name = "Mary Williams"}
        //    };
        //}
    }
}