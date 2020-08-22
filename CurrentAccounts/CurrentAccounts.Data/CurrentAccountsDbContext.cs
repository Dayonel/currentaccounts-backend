using Microsoft.EntityFrameworkCore;

namespace CurrentAccounts.Data
{
    public class CurrentAccountsDbContext : DbContext
    {
        public CurrentAccountsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
