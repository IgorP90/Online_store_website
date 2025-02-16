using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Caching.Distributed;
using static Confluent.Kafka.ConfigPropertyNames;

namespace backend.Controllers
{
    /// <summary>
    /// API Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly Context context;
        private readonly IDistributedCache cache;

        /// <summary>
        /// Constructor for HomeController class
        /// </summary>
        /// <param name="context">DBContext configuration class</param>
        /// <param name="cache">Redis configuration class</param>

        public HomeController(Context context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }
        /// <summary>
        /// Getting the entire list of products from the database
        /// </summary>
        /// <returns>List of products and response status codes</returns>
        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<IEnumerable<IProduct>>> GetAllProducts()
        {
            IEnumerable<IProduct> products = await new Read(context, cache).ReadRow<Product>();
            if (products.IsNullOrEmpty()) return BadRequest("Not Found");
            return Ok(products);
        }
        /// <summary>
        /// Getting product by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>The product and response status codes</returns>
        [HttpGet]
        [Route("productById/{id}")]
        public async Task<ActionResult<IProduct>> GetProductById(int id)
        {
            IProduct product = await new Read(context, cache).ReadRow<Product>(id);
            if (product == null) return BadRequest("Not Found");
            return Ok(product);
        }
        /// <summary>
        /// Getting product by name. Used in the search bar on the home page of the website
        /// </summary>
        /// <param name="name">The name of the product in whole or in part</param>
        /// <returns>List of products found and response status codes</returns>
        [HttpGet]
        [Route("productByName/{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            IEnumerable<Product> products = await new Read(context, cache).ReadRow<Product>(name);

            if(products.IsNullOrEmpty()) return BadRequest("Not Found");
            return Ok(products);
        }
        /// <summary>
        /// Getting the entire list of narrow categories
        /// </summary>
        /// <returns>List of narrow categories and response status codes</returns>
        [HttpGet]
        [Route("narrow_category")]
        public async Task<IEnumerable<NarrowCategory>> GetAllNarrowCategories()
        {
            return await new Read(context, cache).ReadRow<NarrowCategory>();
        }
        /// <summary>
        /// Getting the entire list of wide categories
        /// </summary>
        /// <returns>List of wide categories and response status codes</returns>
        [HttpGet]
        [Route("wide_category")]
        public async Task<IEnumerable<WideCategory>> GetAllWideCategories()
        {
            return await new Read(context, cache).ReadRow<WideCategory>();
        }
        /// <summary>
        /// Selecting a list of products by narrow category name
        /// </summary>
        /// <param name="categoryName">Narrow category name</param>
        /// <returns>List of products and response status codes</returns>
        [HttpGet]
        [Route("productsByNarrowCategory/{categoryName}")]
        public async Task<IEnumerable<Product>> GetAllProductsByNarrowCategory(string categoryName)
        {
            return await new Read(context, cache).ReadRowByNarrowCategory<Product>(categoryName);
        }
        /// <summary>
        /// Selecting a list of products by wide category name
        /// </summary>
        /// <param name="categoryName">Wide category name</param>
        /// <returns>List of products and response status codes</returns>
        [HttpGet]
        [Route("productsByWideCategory/{categoryName}")] //-
        public IEnumerable<Product> GetAllProductsByWideCategory(string categoryName)
        {
            return new Read(context, cache).ReadRowByWideCategory<Product>(categoryName);
        }
        /// <summary>
        /// Creating a new product record in the database
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Response status codes</returns>
        [HttpPost]
        [Route("post_Product")]
        public async Task<ActionResult> PostProduct(Product product) //-
        {
            await new Create(context).CreateRow<Product>(product);
            return Ok();
        }
        /// <summary>
        /// Changing an existing product record in the database
        /// </summary>
        /// <param name="product">Product</param>
        [HttpPut]
        [Route("put_Product")]
        public void UpdateProduct(Product product) // -
        {
            new Update(context).UpdateRow(product);
        }
        /// <summary>
        /// Deleting a product record from the database
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Response status codes</returns>
        [HttpDelete]
        [Route("delete_Product")]
        public ActionResult DeleteProduct(int id)
        {
            new Delete(context).DeleteRow<Product>(id);
            return Ok();
        }
        /// <summary>
        /// Deleting a narrow category record from the database
        /// </summary>
        /// <param name="id">Narrow_category id</param>
        [HttpDelete]
        [Route("delete_narrow_category")]
        public void DeleteNarrowCategory(int id) //-
        {
            //new Delete(context).DeleteRow<NarrowCategory>(id);
        }
    }
}
