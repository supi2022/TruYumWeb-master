using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    [AllowAnonymous]
    public class AnonymousUserController : ControllerBase
    {
        // GET: api/AnonymousUser
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            var menu= AdminController.ls;

            var cats = CategoryController.categories;
            foreach(MenuItem item in menu)
            {
                item.Category = cats.Where(c => c.Id == item.categoryId).FirstOrDefault();
            }

            return menu;
        }

        
    }
}
