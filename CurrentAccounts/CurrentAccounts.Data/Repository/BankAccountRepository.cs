using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccounts.Data.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly CurrentAccountsDbContext _dbContext;
        public BankAccountRepository(CurrentAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(BankAccount bankAccount)
        {
            bankAccount.DateCreated = DateTime.UtcNow;
            _dbContext.BankAccounts.Add(bankAccount);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IReadOnlyCollection<BankAccount>> GetByCustomerId(int customerId)
        {
            return await _dbContext.BankAccounts
                .Where(b => b.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<bool> Update(BankAccount bankAccount)
        {
            var dbBankAccount = await _dbContext.BankAccounts.FindAsync(bankAccount.Id);

            dbBankAccount.Balance = bankAccount.Balance;
            dbBankAccount.DateUpdated = DateTime.UtcNow;

            _dbContext.BankAccounts.Update(dbBankAccount);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
