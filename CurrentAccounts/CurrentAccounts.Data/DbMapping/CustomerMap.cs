using CurrentAccounts.Core.Constants;
using CurrentAccounts.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrentAccounts.Data.DbMapping
{
    public static class CustomerMap
    {
        public static ModelBuilder MapCustomers(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Customer> entity = modelBuilder.Entity<Customer>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasMany(p => p.BankAccounts)
                  .WithOne(o => o.Customer)
                  .HasForeignKey(f => f.CustomerId);

            // Length
            entity.Property(p => p.Name).HasMaxLength(PropertyConstants.DEFAULT_LENGTH);
            entity.Property(p => p.Surname).HasMaxLength(PropertyConstants.DEFAULT_LENGTH);

            return modelBuilder;
        }
    }
}
