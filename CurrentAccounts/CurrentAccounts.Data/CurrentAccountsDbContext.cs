using CurrentAccounts.Data.DbMapping;
using CurrentAccounts.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CurrentAccounts.Data
{
    public class CurrentAccountsDbContext : DbContext
    {
        public CurrentAccountsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.MapCustomers();
            builder.MapBankAccounts();
            builder.MapTransactions();
        }
    }
}
