using System;
using Microsoft.EntityFrameworkCore;

namespace Week4EF.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> contacts { get; set; }

    }

    public class Contact
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
    }
}
