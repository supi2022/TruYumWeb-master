using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        

        // POST: api/Menu
        [HttpPost]
        public string Post([FromBody] MenuItem menu)
        {
            AdminController.ls.Add(menu);
            return "Data Inserted";
        }
    }
}
