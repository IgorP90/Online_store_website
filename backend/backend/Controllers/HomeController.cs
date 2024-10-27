﻿using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product product = await new Read(context).ReadRow<Product>(id);

            if (product.Id == id) return Ok(product);
            else return BadRequest("Not Found");
        }

        [HttpGet]
        [Route("productByName/{name}")]
        public ActionResult<IEnumerable<Product>> GetProductByName(string name)
        {
            IEnumerable<Product> products = new Read(context).ReadRow<Product>(name);

            if (products.Any()) return Ok(products);
            else return BadRequest("Not Found");   
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

        [HttpDelete]
        [Route("delete_Product")]
        public void Delete(int id)
        {
            new Delete(context).DeleteRow<Product>(id);    
        }

        #region //--------------------------------------------------------------------

        /*[HttpGet]
        [Route("product")]
        public IQueryable<Product> GetAllProducts()      

        [HttpGet]
        [Route("productByDate")]
        public IEnumerable<Product> GetAllProductsByDate()       

        [HttpGet]
        [Route("productByRating")]
        public IEnumerable<Product> GetAllProductsByRating()     

        [HttpGet]
        [Route("productById/{id}")]
        public Product GetProductById(int id)      

        [HttpGet]
        [Route("productbyName/{name}")]
        public IEnumerable<Product> GetProductByName(string name)       

        [HttpGet]
        [Route("productsByNarrowCategory/{categoryName}")]
        public IEnumerable<Product> GetAllNarrowCategories(string categoryName)

        [HttpPost]
        [Route("addProduct/{id}")]
        public void PostProduct(Product product)      

        [HttpGet]
        [Route("wide_category")]
        public IEnumerable<WideCategory> GetAllWideCategories()
 
        [HttpGet]
        [Route("productsByWideCategory/{name}")]
        public IEnumerable<Product> GetWideCategoryByName(string name)

        [HttpGet]
        [Route("narrow_category")]
        public IEnumerable<NarrowCategory> GetAllNarrowCategories()

        [HttpGet]
        [Route("shopping_cart")]
        public IEnumerable<ShoppingСart> GetShoppingCart()

        [HttpPost]
        [Route("shopping_cart/{id}")]
        public void PostShoppingCart(int id)*/
        #endregion


        [HttpGet]
        [Route("Tets_Get_Products")]
        public IEnumerable<Product> Test()
        {
            return new Read(context).ReadRow<Product>();
        }

        /*[HttpGet]
        [Route("Tets_Get_Product_By_Id")]
        public IEnumerable<Product> Test(int id)
        {
            return new Read(context).ReadRow<Product>(id);
        }*/

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
    }
}
