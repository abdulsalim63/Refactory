using System;
using Microsoft.EntityFrameworkCore;

namespace Week4JWTAuth.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}
