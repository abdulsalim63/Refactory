using System;
using Microsoft.EntityFrameworkCore;
using Merchant.Domain.Entities;

namespace Merchant.Infrastructure
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<MerchantModel> merchants { get; set; }
    }
}
