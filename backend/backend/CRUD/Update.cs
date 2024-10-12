using backend.Models;

namespace backend.CRUD
{
    public class Update
    {
        private readonly Context context;

        public Update(Context context) => this.context = context;

        public void UpdateRow(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
