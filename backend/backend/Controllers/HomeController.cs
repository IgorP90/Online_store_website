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

        [HttpGet]
        [Route("productsByWideCategory/{categoryName}")]
        public IEnumerable<Product> GetAllProductsByWideCategory(string categoryName)
        {
            return new Read(context).ReadRowByWideCategory<Product>(categoryName);
        }

        [HttpPut]
        [Route("put_Product")]
        public void UpdateProduct(Product product) // -
        {
            new Update(context).UpdateRow(product);
        }

        #region //--------------------------------------------------------------------

        /*[HttpGet]
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
        }*/
        #endregion


        [HttpGet]
        [Route("Tets_Get_Products")]
        public IEnumerable<Product> Test()
        {
            return new Read(context).ReadRow<Product>();
        }

        [HttpGet]
        [Route("Tets_Get_Product_By_Id")]
        public IEnumerable<Product> Test(int id)
        {
            return new Read(context).ReadRow<Product>(id);
        }

        [HttpGet]
        [Route("Tets_Get_Product_By_Name")]
        public IEnumerable<Product> Test(string name)
        {
            return new Read(context).ReadRow<Product>(name);
        }

        [HttpPost]
        [Route("Tets_Post_Product")]
        public void Test2(Product product)
        {
            new Create(context).CreateRow<Product>(product);
        }


        [HttpDelete]
        [Route("Tets_Delete_Product_By_Id")]
        public void Test3(int id)
        {
            new Delete(context).DeleteRow<Product>(id);
        }
    }
}
