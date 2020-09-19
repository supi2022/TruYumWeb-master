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
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        public static List<MenuItem> ls = new List<MenuItem>
        {
            new MenuItem
            {
                Id=1,
                Name="Chowmein",
                freeDelivery=true,
                Price=30.50,
                Active=true,
                DateOfLaunch=new DateTime(2020,09,18),
                categoryId=101

            },
            new MenuItem
            {
                Id=2,
                Name="Fried Rice",
                freeDelivery=true,
                Price=50.00,
                Active=true,
                DateOfLaunch=new DateTime(2020,09,18),
                categoryId=101
            }
        };
        
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return ls;
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] MenuItem value)
        {
            MenuItem item = ls.Where(i => i.Id == id).FirstOrDefault();

            if (item != null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Price = value.Price;
                item.freeDelivery = value.freeDelivery;
                item.Active = value.Active;
                item.DateOfLaunch = value.DateOfLaunch;
                item.categoryId = value.categoryId;
            }

            return "Data Updated";
        }

        
    }
}
