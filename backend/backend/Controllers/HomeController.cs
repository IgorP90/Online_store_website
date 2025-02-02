using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Caching.Distributed;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly Context context;
        private readonly IDistributedCache cache;

        public HomeController(Context context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<IEnumerable<IProduct>>> GetAllProducts()
        {
            IEnumerable<IProduct> products = await new Read(context, cache).ReadRow<Product>();
            if (products.IsNullOrEmpty()) return BadRequest("Not Found");
            return Ok(products);
        }

        [HttpGet]
        [Route("productById/{id}")]
        public async Task<ActionResult<IProduct>> GetProductById(int id)
        {
            IProduct product = await new Read(context, cache).ReadRow<Product>(id);
            if (product == null) return BadRequest("Not Found");
            return Ok(product);
        }

        [HttpGet]
        [Route("productByName/{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            IEnumerable<Product> products = await new Read(context, cache).ReadRow<Product>(name);
            if(products.IsNullOrEmpty()) return BadRequest("Not Found");
            return Ok(products);
        }

        [HttpGet]
        [Route("narrow_category")]
        public async Task<IEnumerable<NarrowCategory>> GetAllNarrowCategories()
        {
            return await new Read(context, cache).ReadRow<NarrowCategory>();
        }

        [HttpGet]
        [Route("wide_category")]
        public async Task<IEnumerable<WideCategory>> GetAllWideCategories()
        {
            return await new Read(context, cache).ReadRow<WideCategory>();
        }

        [HttpGet]
        [Route("productsByNarrowCategory/{categoryName}")]
        public async Task<IEnumerable<Product>> GetAllProductsByNarrowCategory(string categoryName)
        {
            return await new Read(context, cache).ReadRowByNarrowCategory<Product>(categoryName);
        }

        [HttpGet]
        [Route("productsByWideCategory/{categoryName}")]
        public IEnumerable<Product> GetAllProductsByWideCategory(string categoryName)
        {
            return new Read(context, cache).ReadRowByWideCategory<Product>(categoryName);
        }

        [HttpPost]
        [Route("post_Product")]
        public async Task<ActionResult> PostProduct(Product product)
        {
            await new Create(context).CreateRow<Product>(product);
            return Ok();
        }

        [HttpPut]
        [Route("put_Product")]
        public void UpdateProduct(Product product)
        {
            new Update(context).UpdateRow(product);
        }

        [HttpDelete]
        [Route("delete_Product")]
        public ActionResult DeleteProduct(int id)
        {
            new Delete(context).DeleteRow<Product>(id);
            return Ok();
        }
    }
}
