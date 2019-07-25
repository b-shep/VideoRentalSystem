using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalSystem.Models;
using System.Data.Entity;


namespace VideoRentalSystem.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Customers/Index")]
        public ActionResult Index()
        {                                     //loads membership type object instead of just membership.id
                                                                               //causes db access to initiailize on startup instead of when called in stack. also parses to list
           var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        [Route("Customers/Detail/{id}")]
        public ActionResult Detail(int id)
        {                                       //selects single element if exists or default if doesn't
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}