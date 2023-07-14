using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.CRUD
{
    public class RequestHandler
    {
        private readonly Context context;
        public RequestHandler(Context context) => this.context = context;
        public IEnumerable<Product> Read() 
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> Read(string name)
        {
            return context.Products.Where(n => n.Name == name).ToList();
        }

        public void Create(Product product) 
        {
            context.Add(product);
            context.SaveChanges();
        }
    }
}
