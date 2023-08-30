using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace backend.CRUD
{
    public class ProductHandler
    {
        private readonly Context context;
        public ProductHandler(Context context) => this.context = context;


        public IQueryable<Product> Read()
        {
            return context.Products;      
        }

        public Product Read(int id)
        {
            return context.Products.Where(n => n.Id == id).First();
        }

        public IEnumerable<Product> Read(string name)
        {
            return context.Products.Where(n => EF.Functions.Like(n.Name, $"%{name}%")).Take(10);
        }

        public IEnumerable<Product> ReadByDate()
        {
            return context.Products.OrderByDescending(n => n.DateTime).Take(5);
        }

        public IEnumerable<Product> ReadByRating()
        {
            return context.Products.OrderByDescending(n => n.Rating).Take(3);
        }

        public IEnumerable<Product> ReadByNarrowCategory(string name)
        {
            int nm = context.NarrowCategories.Where(n => n.Name == name).Select(n=>n.Id).First();

            return context.Products.Where(n => n.NarrowCategoryId == nm);
            //return context.NarrowCategories.Where(n => n.Name == name).Take(10);
        }

        public void Create(Product product) 
        {
            context.Add(product);
            context.SaveChanges();            
        }
    }
}
