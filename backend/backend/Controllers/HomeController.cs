using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("product")]
        public Product GetProduct()
        {
            return new Product
            {
                Id = 1234,
                Name = "Apple",
                Description = "Red apple",
                Price = 1000
            };
        }
        [HttpGet]
        [Route("category")]
        public Category GetCategory()
        {
            return new Category
            {
                Name = "Охота",
                Image = "assets/images/Hunting.webp"
            };
        }
    }
}
