using CurrentAccounts.Core.Interfaces.Repository.Base;
using System;
using System.Threading.Tasks;

namespace CurrentAccounts.Data.Repository.Base
{
    public class TransactionScopedRepository : ITransactionScopedRepository
    {
        private readonly CurrentAccountsDbContext _dbContext;
        public TransactionScopedRepository(CurrentAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExecuteScoped(Func<Task<bool>> function)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!await function())
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
