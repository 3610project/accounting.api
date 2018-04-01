using Accounting.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Data
{
    public class AccountingContext : DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        public DbSet<Transaction> Transactions { get; set; }

    }
}