using Microsoft.EntityFrameworkCore;

namespace Week3WebAPI2.Models
{
    public class PhotoContext : DbContext
    {
        public PhotoContext(DbContextOptions<PhotoContext> options)
            : base(options)
        {
        }

        public DbSet<Photo> PhotoItems { get; set; }
    }
}