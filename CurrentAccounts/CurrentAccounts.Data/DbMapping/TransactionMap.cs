using CurrentAccounts.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrentAccounts.Data.DbMapping
{
    public static class TransactionMap
    {
        public static ModelBuilder MapTransactions(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Transaction> entity = modelBuilder.Entity<Transaction>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasOne(p => p.BankAccount)
                  .WithMany(o => o.Transactions)
                  .HasForeignKey(f => f.BankAccountId);

            return modelBuilder;
        }
    }
}
