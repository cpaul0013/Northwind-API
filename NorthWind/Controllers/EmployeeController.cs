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
    public class EmployeeController : ControllerBase
    {
        [HttpGet("/Employee/getAll")]
        public List<Employee> GetAllEmployees()
        {
            //make a list to make sure nothing weird happens in the using statement
            List<Employee> result = null;
            //need using statement for ef databse stuff
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Employees.ToList();


            }

            return result;
        }
        // api/Employee/getCustomerById
        [HttpGet("/EmployeeById/{EmployeeId}")]
        public Employee getEmployeeById(int EmployeeId)
        {

            Employee FrankTheTank = null;
            using (NorthwindContext context = new NorthwindContext())
            {

                FrankTheTank = context.Employees.Find(EmployeeId);



            }

            return FrankTheTank;

        }


        [HttpPost("/Employee/Add")]
        public Employee CreateCustomer(string firstname, string lastname, string title)
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = firstname;
            newEmployee.LastName = lastname;
            newEmployee.Title = title;
            using (NorthwindContext context = new NorthwindContext())
            {

                context.Employees.Add(newEmployee);
                context.SaveChanges();

            }
            return newEmployee;
        }






    }
}
