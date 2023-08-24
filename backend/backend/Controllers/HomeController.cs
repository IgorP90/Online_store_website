using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
            return new ProductHandler(context).Read();
        }

        [HttpGet]
        [Route("productByDate")]
        public IQueryable<Product> GetAllProductsByDate()
        {
            return new ProductHandler(context).ReadByDataTime();
        }

        [HttpGet]
        [Route("productByRating")]
        public IQueryable<Product> GetAllProductsByRating()
        {
            return new ProductHandler(context).ReadByRating();
        }

        [HttpGet]
        [Route("productById/{id}")]
        public IQueryable<Product> GetProductById(int id)
        {
            return new ProductHandler(context).Read(id);
        }

        [HttpGet]
        [Route("productbyName/{name}")]
        public IQueryable<Product> GetProductByName(string name)
        {
            return new ProductHandler(context).Read(name);
        }

        [HttpPost]
        [Route("addProduct/{id}")]
        public void PostProduct(Product product) 
        {
            new ProductHandler(context).Create(product);
        }

        [HttpGet]
        [Route("wide_category")]
        public IEnumerable<WideCategory> GetAllWideCategories()
        {
            return new WideCategoryHandler(context).Read();
        }

        [HttpGet]
        [Route("wide_category/{name}")]
        public IEnumerable<WideCategory> GetWideCategoryByName(string name)
        {
            return new WideCategoryHandler(context).Read(name);
        }

        [HttpGet]
        [Route("narrow_category")]
        public IEnumerable<NarrowCategory> GetAllNarrowCategories()
        {
            return new NarrowCategoryHandler(context).Read();
        }

        [HttpGet]
        [Route("shopping_cart")]
        public IEnumerable<ShoppingСart> GetShoppingCart()
        {
            return new ShoppingCartHandler(context).Read();
        }

        [HttpGet]
        [Route("shopping_cart/{id}")]
        public void PostShoppingCart(int id)
        {
            new ShoppingCartHandler(context).Post(id);
        }

    }
}
