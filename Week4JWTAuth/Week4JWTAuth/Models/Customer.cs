using System;
using Microsoft.EntityFrameworkCore;

namespace Week4JWTAuth.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
    }

    public class Customer
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}