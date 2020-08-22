using CurrentAccounts.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrentAccounts.Data.DbMapping
{
    public static class BankAccountMap
    {
        public static ModelBuilder MapBankAccounts(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<BankAccount> entity = modelBuilder.Entity<BankAccount>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasMany(p => p.Transactions)
                  .WithOne(o => o.BankAccount)
                  .HasForeignKey(f => f.BankAccountId);

            return modelBuilder;
        }
    }
}
