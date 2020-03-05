using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week5Mediator.Domain.Models;

namespace Week5Mediator.Application.Interfaces
{
    public interface IBlogContext
    {
        public DbSet<Merchant> merchants { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerCard> customerCards { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
