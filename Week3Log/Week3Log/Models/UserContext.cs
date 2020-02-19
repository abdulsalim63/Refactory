using System;
using Microsoft.EntityFrameworkCore;

namespace Week3Log.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> UserDb { get; set; }
    }
}
