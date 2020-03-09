using System;
using CustomerAndCustomerCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAndCustomerCard.Infrastructure
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerCard> customercards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerCard>()
                .HasOne(o => o.Customer)
                .WithOne(m => m.CustomerCard)
                .HasForeignKey<CustomerCard>(key => key.customer_id);
        }
    }
}
