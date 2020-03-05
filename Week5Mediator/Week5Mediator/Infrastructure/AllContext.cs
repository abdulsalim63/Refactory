using System;
using Microsoft.EntityFrameworkCore;
using Week5Mediator.Domain.Models;
using Week5Mediator.Application.Interfaces;

namespace Week5Mediator.Infrastructure
{
    public class AllContext : DbContext, IBlogContext
    {
        public AllContext(DbContextOptions<AllContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerCard> customerCards { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Merchant> merchants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                    .HasOne(c => c.CustomerCard)
                    .WithOne(c => c.Customer)
                    .HasForeignKey<CustomerCard>(c => c.customer_id);

            modelBuilder.Entity<Product>()
                    .HasOne(o => o.Merchant)
                    .WithMany(m => m.Product)
                    .HasForeignKey(f => f.merchant_id);
        }
    }
}
