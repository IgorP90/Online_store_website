using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.CRUD
{
    public class ProductHandler
    {
        private readonly Context context;
        public ProductHandler(Context context) => this.context = context;

        public IEnumerable<Product> Read() 
        {
            return context.Products;
        }

        public IQueryable<Product> Read(int id)
        {          
            return context.Products.Where(n => n.Id == id);
        }

        public IQueryable<Product> Read(string name)
        {
            return context.Products.Where(n => EF.Functions.Like(n.Name, $"%{name}%")).Take(10);
        }

        public IQueryable<Product> ReadByDataTime()
        {
            return context.Products.OrderByDescending(n=>n.DateTime).Take(5);
        }

        public IQueryable<Product> ReadByRating()
        {
            return context.Products.OrderByDescending(n => n.Rating).Take(3);
        }

        public void Create(Product product) 
        {
            context.Add(product);
            context.SaveChanges();
        }
    }
}
