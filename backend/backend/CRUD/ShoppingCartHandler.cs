using backend.Models;

namespace backend.CRUD
{
    public class ShoppingCartHandler
    {
        private readonly Context context;
        public ShoppingCartHandler(Context context) => this.context = context;

        public IQueryable<ShoppingСart> Read()
        {
            return context.ShoppingСart;
        }

        public void Post(int id)
        {
            IQueryable<int> res = context.Products.Where(n => n.Id == id).Select(n=>n.Id);
                
                //context.ShoppingСart.Add(new ShoppingСart {ProductId = id});
                //context.SaveChanges();
        }
    }
}
