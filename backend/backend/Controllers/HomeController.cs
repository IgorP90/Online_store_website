using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public IQueryable<Product> GetAllProducts()
        {
            return new ProductHandler(context).Read();
        }

        [HttpGet]
        [Route("productByDate")]
        public IEnumerable<Product> GetAllProductsByDate()
        {
            return new ProductHandler(context).ReadByDate();
        }

        [HttpGet]
        [Route("productByRating")]
        public IEnumerable<Product> GetAllProductsByRating()
        {
            return new ProductHandler(context).ReadByRating();
        }

        [HttpGet]
        [Route("productById/{id}")]
        public Product GetProductById(int id)
        {
            return new ProductHandler(context).Read(id);
        }

        [HttpGet]
        [Route("productbyName/{name}")]
        public IEnumerable<Product> GetProductByName(string name)
        {
            return new ProductHandler(context).Read(name);
        }

        [HttpGet]
        [Route("productsByNarrowCategory/{categoryName}")]
        public IEnumerable<Product> GetAllNarrowCategories(string categoryName)
        {
            return new ProductHandler(context).ReadByNarrowCategory(categoryName);
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
        [Route("productsByWideCategory/{name}")]
        public IEnumerable<Product> GetWideCategoryByName(string name)
        {
            return new ProductHandler(context).ReadByWideCategory(name);
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

        [HttpPost]
        [Route("shopping_cart/{id}")]
        public void PostShoppingCart(int id)
        {
            new ShoppingCartHandler(context).Post(id);
        }

    }
}
