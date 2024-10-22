using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> GetCustomers() => new List<Customer>
        {
            new Customer { Id = 1, Name = "Customer 1" },
            new Customer { Id = 2, Name = "Customer 2" }
        };

        // GET: Customers
        [Route("customers")]
        public ActionResult Customers()
        {
            var customers = GetCustomers();

            var viewModel = new CustomerListViewModel
            {
                Customers = customers
            };

            return View(viewModel);

        }

        // GET: Customers/Details/id
        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = GetCustomers();

            var customer = customers.Find(c => c.Id == id);

            return View(customer);
        }
    }
}