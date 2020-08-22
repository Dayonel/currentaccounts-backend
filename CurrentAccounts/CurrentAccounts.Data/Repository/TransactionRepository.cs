using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccounts.Data.Repository
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly CurrentAccountsDbContext _dbContext;
        public TransactionRepository(CurrentAccountsDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            await _dbContext.SaveChangesAsync();
            return transaction.Id;
        }

        public async Task<IReadOnlyCollection<Transaction>> GetByBankAccountId(int bankAccountId)
        {
            return await _dbContext.Transactions
                .Where(t => t.BankAccountId == bankAccountId)
                .ToListAsync();
        }
    }
}
