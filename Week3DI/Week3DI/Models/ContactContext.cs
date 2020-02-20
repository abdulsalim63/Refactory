using System;
using Microsoft.EntityFrameworkCore;

namespace Week3DI.Models
{
    public class ContactContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=ContactDb;Username=my_user;Password=my_pw");

        public DbSet<Contact> Contacts { get; set; }
    }
}
