using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {   
        // api/Customer/getAll
        
        [HttpGet("/Customer/getAll")]
        public List<Customer> GetAllCustomers()
        {
            //make a list to make sure nothing weird happens in the using statement
            List<Customer> result = null;
            //need using statement for ef databse stuff
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Customers.ToList();


            }

            return result;
        }
        // api/Customer/getCustomerById
        [HttpGet("/CustomerById/{CustomerId}")]
        public Customer getCustomerById(string CustomerId)
        {

            Customer FrankTheTank = null;
            using (NorthwindContext context = new NorthwindContext())
            {

                FrankTheTank = context.Customers.Find(CustomerId);



            }

            return FrankTheTank;



        }

        [HttpPost("/Customer/Add")]
        public Customer CreateCustomer(string companyname, string contactname, string contacttitle)
        {
            Customer newCustomer = new Customer();
            newCustomer.CompanyName = companyname;
            newCustomer.ContactName = contactname;
            newCustomer.ContactTitle = contacttitle;
            using (NorthwindContext context = new NorthwindContext())
            {

                context.Customers.Add(newCustomer);
                context.SaveChanges();

            }
            return newCustomer;
        }


    }
}
