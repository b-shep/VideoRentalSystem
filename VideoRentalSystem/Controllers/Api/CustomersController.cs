
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VideoRentalSystem.Models;

namespace VideoRentalSystem.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public JsonResponse GetCustomers()
        {
            JsonResponse jr = null;
            try
            {
                jr = JsonResponse.getInstance(_context.Customers.ToList());
            }
            catch (Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }
            return jr;

        }

        //GET /api/customers/{id}
        public JsonResponse GetCustomer(int id)
        {
            JsonResponse jr = null;
            try
            {
                jr = JsonResponse.getInstance(_context.Customers.Single(c => c.Id == id));
            }
            catch (Exception e)
            {
                return new JsonResponse(e);
            }
            return jr;
        }

        //POST /api/customers/create
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            JsonResponse jr = null;

            try
            {
                _context.Customers.Add(customer);
                jr = JsonResponse.getInstance(_context.SaveChanges());
            } catch(Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }
            
            return customer;
        }

        //PUT api/customers/{id}
        [HttpPut]
        public JsonResponse EditCustomer(Customer customer)
        {

            JsonResponse jr = null;

            try
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (!ModelState.IsValid)
                {
                    jr = JsonResponse.getInstance("Error: Invalid customer fields");
                }
                else if (customerInDb == null)
                {
                    jr = JsonResponse.getInstance("Error: Customer with id=" + customer.Id + "could not be found in database.");
                }
                else
                {
                    customerInDb.Name = customer.Name;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    _context.SaveChanges();

                    jr = JsonResponse.getInstance(customerInDb);
                }
            }
            catch (Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }

            return jr;
        }

        //DELETE api/customers/1
        [HttpDelete]
        public JsonResponse DeleteCustomer(int id)
        {
            JsonResponse jr = null;

            try
            {

                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customerInDb == null)
                {
                    jr = JsonResponse.getInstance("Error: Customer with id=" + id + "could not be found in database.");
                }
                else
                {
                    _context.Customers.Remove(customerInDb);

                   jr =JsonResponse.getInstance (_context.SaveChanges());
                }
            } catch(Exception e)
            {
                jr = JsonResponse.getInstance(e);
            }
            return jr;

        }

    }
}
