using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Week5Decorator.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerCard> customerCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                    .HasOne(c => c.CustomerCard)
                    .WithOne(c => c.Customer)
                    .HasForeignKey<CustomerCard>(c => c.customer_id);
        }
    }

    public enum Gender
    {
        male = 0,
        female = 1
    }

    public class Customer : Parent
    {
        public string full_name { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }

    public class CustomerCard : Parent
    {
        public string name_on_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }

        public int customer_id { get; set; }
        public Customer Customer { get; set; }
    }
}
