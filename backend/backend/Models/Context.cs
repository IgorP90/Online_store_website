using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace backend.Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoties { get; set; }
        public DbSet<Order> Orders { get; set; }


        public Context(DbContextOptions<Context> options) : base(options){}

    }
}
