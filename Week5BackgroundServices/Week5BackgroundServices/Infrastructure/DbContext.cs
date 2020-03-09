using System;
using Microsoft.EntityFrameworkCore;
using Week5BackgroundServices.Domain.Entities;

namespace Week5BackgroundServices.Infrastructure
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerCard> customercards { get; set; }
        public DbSet<Merchant> merchants { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerCard>()
                .HasOne(o => o.Customer)
                .WithOne(m => m.CustomerCard)
                .HasForeignKey<CustomerCard>(key => key.customer_id);

            modelBuilder.Entity<Product>()
                .HasOne(o => o.Merchant)
                .WithMany(m => m.Product)
                .HasForeignKey(key => key.merchant_id);
        }
    }
}
