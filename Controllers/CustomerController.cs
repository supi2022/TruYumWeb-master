using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        private static List<Cart> carts = new List<Cart>();

        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            var menu = AdminController.ls;
            List<MenuItem> list = new List<MenuItem>();
            foreach (var x in menu)
            {
                if (x.Active == true && x.DateOfLaunch < DateTime.Now)
                {
                    list.Add(x);
                }
            }
            return list;

        }


        [HttpGet("{UserId}")]
        public IEnumerable<Cart> Get(int UserId)
        {
            return carts.Where(c => c.userId == UserId);  // Total Price is Not included
        }

        [HttpPost]
        public string Post([FromBody] Cart item)
        {
            
            carts.Add(item);
            return "Added to Cart";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            
            carts.Remove(carts.Where(c => c.id == id).FirstOrDefault());
            return "Removed from Cart";
        }
    }
}