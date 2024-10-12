using backend.CRUD;

namespace backend.Models
{
    public static class Initializer
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                using Context context = scope.ServiceProvider.GetRequiredService<Context>();
                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    throw;
                }

                IEnumerable<NarrowCategory> narrowCategories = JSONDeserializer.JSONDeserializ<NarrowCategory>("NarrowCategories.json");
                IEnumerable<WideCategory> wideCategories = JSONDeserializer.JSONDeserializ<WideCategory>("WideCategories.json");
                IEnumerable<Product> products = JSONDeserializer.JSONDeserializ<Product>("Product.json");

                foreach (NarrowCategory item in narrowCategories) new Create(context).CreateRow<NarrowCategory>(item);
                foreach (WideCategory item in wideCategories) new Create(context).CreateRow<WideCategory>(item);
                foreach (Product item in products) new Create(context).CreateRow<Product>(item);

                foreach (Product product in products)
                {
                    foreach (var wideCategory in wideCategories)
                    {
                        wideCategory.Products.Add(product);
                        product.WideCategories.Add(wideCategory);                    
                    }
                }



                return app;
            }
        }
    }
}
