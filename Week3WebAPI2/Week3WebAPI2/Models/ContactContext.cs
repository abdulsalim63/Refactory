using Microsoft.EntityFrameworkCore;

namespace Week3WebAPI2.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> ContactItems { get; set; }
    }
}