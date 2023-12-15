using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;
using NPOI.OpenXmlFormats.Wordprocessing;

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

        [Authorize]
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModels
            {
                Customer = new CustomerModels(),
                MembershipTypes = _context.MembershipTypes.ToList()
        };
            return View("CustomerForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Save(CustomerModels customer) {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModels
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                // Check if the phone number is already in use
                if (_context.Customers.FirstOrDefault(c => c.Name == customer.Name && c.PhoneNumber == customer.PhoneNumber) != null)
                {
                    ViewBag.ErrorMessage = "The user already exists.";
                    var viewModel = new CustomerFormViewModels
                    {
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("CustomerForm", viewModel);
                }
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
             return RedirectToAction("Index", "Customer");
        }

        public ViewResult Index() {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModels
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            // Retrieve the customer from the database
            var customer = _context.Customers.Find(id);

            // Check if the customer exists
            if (customer == null)
            {
                return HttpNotFound();
            }

            // Remove the customer from the context and save changes
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            // Redirect to the index action (or any other desired action)
            return RedirectToAction("Index", "Customer");
        }
    }
}