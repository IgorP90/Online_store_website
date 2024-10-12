using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly Context context;

        public HomeController(Context context) => this.context = context;

        [HttpGet]
        [Route("product")]
        public IEnumerable<Product> GetAllProducts()
        {
            return new Read(context).ReadRow<Product>();
        }

        [HttpGet]
        [Route("productById/{id}")]
        public Product GetProductById(int id)
        {
            return new Read(context).ReadRow<Product>(id).First();
        }

        [HttpGet]
        [Route("productByName/{name}")]
        public Product GetProductByName(string name)
        {
            try
            {
                return new Read(context).ReadRow<Product>(name).First();
            }
            catch (Exception)
            {
                return null;
            }    
        }

        [HttpGet]
        [Route("narrow_category")]
        public IEnumerable<NarrowCategory> GetAllNarrowCategories()
        {
            return new Read(context).ReadRow<NarrowCategory>();
        }

        [HttpGet]
        [Route("wide_category")]
        public IEnumerable<WideCategory> GetAllWideCategories()
        {
            return new Read(context).ReadRow<WideCategory>();
        }

        [HttpGet]
        [Route("productsByNarrowCategory/{categoryName}")]
        public IEnumerable<Product> GetAllProductsByNarrowCategory(string categoryName)
        {
            return new Read(context).ReadRowByNarrowCategory<Product>(categoryName);
        }
    }
}
