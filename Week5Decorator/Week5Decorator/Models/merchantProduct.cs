using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Week5Decorator.Models
{
    public class MerchantProductContext : DbContext
    {
        public MerchantProductContext(DbContextOptions<MerchantProductContext> options) : base(options)
        {
        }

        public DbSet<Merchant> merchants { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(o => o.Merchant)
                .WithMany(m => m.Product)
                .HasForeignKey(f => f.merchant_id);
        }
    }

    public class Merchant : Parent
    {
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }

        public List<Product> Product { get; set; }
    }

    public class Product : Parent
    {
        public string name { get; set; }
        public int price { get; set; }

        public int merchant_id { get; set; }
        public Merchant Merchant { get; set; }
    }
}
