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
    public class ProductController : ControllerBase
    {
        [HttpGet("/Product/getAll")]
        public List<Product> GetAllProducts()
        {
            //make a list to make sure nothing weird happens in the using statement
            List<Product> result = null;
            //need using statement for ef databse stuff
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.ToList();


            }

            return result;
        }


        // api/Customer/getProductById
        [HttpGet("/ProductById/{ProductId}")]
        public Product getProductById(int ProductId)
        {

            Product mystery = null;
            using (NorthwindContext context = new NorthwindContext())
            {

                mystery = context.Products.Find(ProductId);



            }

            return mystery;

        }

        [HttpDelete("/ProductDelete/{ProductId}")]
        [HttpDelete("delete/{id}")]
        public Product deleteByProductId(int ProductId)
        {
                Product result = null;
                List<OrderDetail> result1 = null;
                using (NorthwindContext context = new NorthwindContext())
                {
                    result1 = context.OrderDetails.Where(o => o.ProductId == ProductId).ToList();
                    foreach (OrderDetail i in result1)
                    {
                        context.OrderDetails.Remove(i);
                    }
                    context.SaveChanges();
                    result = context.Products.Find(ProductId);
                    if (result != null)
                    {
                        context.Products.Remove(result);
                    }
                    context.SaveChanges();
                }
                return result;
            }




        }
    }
