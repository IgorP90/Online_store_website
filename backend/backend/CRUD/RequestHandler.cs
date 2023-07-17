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

        public IEnumerable<Product> Read(int id)
        {
            return context.Products.Where(n => n.Id == id).ToList();
        }

        public void Create(Product product) 
        {
            context.Add(product);
            context.SaveChanges();
        }
    }
}
