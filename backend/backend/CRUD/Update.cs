using backend.Models;

namespace backend.CRUD
{
    public class Update
    {
        private readonly Context context;

        public Update(Context context) => this.context = context;

        public void UpdateRow(Product product)
        {
            Product res = context.Products.Find(product.Id);

            if (product.Name != res.Name) res.Name = product.Name;
            if (product.Description != res.Description) res.Description = product.Description;
            if (product.Price != res.Price) res.Price = product.Price;

            context.SaveChanges();
        }
    }
}
