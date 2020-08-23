using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccounts.Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CurrentAccountsDbContext _dbContext;
        public TransactionRepository(CurrentAccountsDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Transaction transaction)
        {
            transaction.DateCreated = DateTime.UtcNow;
            _dbContext.Transactions.Add(transaction);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IReadOnlyCollection<Transaction>> GetByBankAccountId(int bankAccountId)
        {
            return await _dbContext.Transactions
                .Where(t => t.BankAccountId == bankAccountId)
                .ToListAsync();
        }

        public async Task<decimal> GetBalanceByBankAccountId(int bankAccountId)
        {
            return await _dbContext.Transactions
                .Where(t => t.BankAccountId == bankAccountId)
                .SumAsync(s => s.Amount);
        }
    }
}
