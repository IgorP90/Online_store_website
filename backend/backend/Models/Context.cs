using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace backend.Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<WideCategory> WideCategories { get; set; }
        public DbSet<NarrowCategory> NarrowCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingСart> ShoppingСart { get; set; }


        public Context(DbContextOptions<Context> options) : base(options){}

    }
}
