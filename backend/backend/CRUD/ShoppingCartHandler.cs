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

        public void Post(int id) //хрень
        {
            int res = context.Products.Where(n => n.Id == id).Select(n=>n.Id).First();

            int quantity = 4;

            if (res != 0)
            {
                int r = context.ShoppingСart.Where(n => n.ProductId == res).Select(n=>n.ProductId).First();
                if (r == 0)
                {
                    context.ShoppingСart.Add(new ShoppingСart { ProductId = id, Quantity = quantity });
                }
                else 
                {
                    
                    
                }
            }

            context.SaveChanges();               
        }
    }
}
