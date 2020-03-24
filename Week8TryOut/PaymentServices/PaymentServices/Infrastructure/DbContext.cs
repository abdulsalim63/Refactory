using System;
using Microsoft.EntityFrameworkCore;
using PaymentServices.Domain.Entities;

namespace PaymentServices.Infrastructure
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        public DbSet<Payment> payments { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Order_Details> order_Details { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
