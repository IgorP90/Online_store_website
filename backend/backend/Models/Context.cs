using backend.CRUD;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace backend.Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<WideCategory> WideCategories { get; set; }
        public DbSet<NarrowCategory> NarrowCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingСart> ShoppingСart { get; set; }
        public DbSet<Test> Test { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {       
           /* this.Database.Migrate();

            IEnumerable<NarrowCategory> narrowCategories = JSONDeserializer.JSONDeserializ<NarrowCategory>("NarrowCategories.json");
            IEnumerable<Product> product = JSONDeserializer.JSONDeserializ<Product>("Product.json");

            foreach (var item in narrowCategories) new NarrowCategoryHandler(this).Create(item);
            foreach (var item in product) new ProductHandler(this).Create(item);*/
        }

    }
}
