using System;
using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User_Model> users { get; set; }
    }
}
