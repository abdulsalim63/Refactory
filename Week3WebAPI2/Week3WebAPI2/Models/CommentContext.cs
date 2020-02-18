using Microsoft.EntityFrameworkCore;

namespace Week3WebAPI2.Models
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> CommentItems { get; set; }
    }
}