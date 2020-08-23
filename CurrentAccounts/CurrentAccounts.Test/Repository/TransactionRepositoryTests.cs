using CurrentAccounts.Core.Entity;
using CurrentAccounts.Data.Repository;
using CurrentAccounts.Test.Repository.Base;
using System;
using System.Linq;
using Xunit;

namespace CurrentAccounts.Test.Repository
{
    public class TransactionRepositoryTests : RepositoryBase
    {
        [Fact]
        public void Transaction_Add()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            _dbContext.BankAccounts.Add(new BankAccount
            {
                DateCreated = DateTime.UtcNow,
                CustomerId = 1
            });
            _dbContext.SaveChanges();

            var transactionRepository = new TransactionRepository(_dbContext);
            transactionRepository.Add(new Transaction
            {
                Amount = 10,
                BankAccountId = 1,
                DateCreated = DateTime.UtcNow
            }).GetAwaiter().GetResult();
            _dbContext.SaveChanges();

            // Act
            var transaction = _dbContext.Transactions.FirstOrDefault();

            // Assert
            Assert.NotNull(transaction);
            Assert.Equal(10, transaction.Amount);
        }

        [Fact]
        public void Transaction_GetByBankAccountId()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            _dbContext.BankAccounts.Add(new BankAccount
            {
                DateCreated = DateTime.UtcNow,
                CustomerId = 1
            });
            _dbContext.SaveChanges();

            _dbContext.Transactions.Add(new Transaction
            {
                Amount = 50,
                BankAccountId = 1,
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            // Act
            var transactionRepository = new TransactionRepository(_dbContext);
            var transaction = transactionRepository.GetByBankAccountId(1).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(transaction.FirstOrDefault());
            Assert.Equal(50, transaction.FirstOrDefault().Amount);
        }

        [Fact]
        public void Transaction_BalanceByBankAccountId()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            _dbContext.BankAccounts.Add(new BankAccount
            {
                DateCreated = DateTime.UtcNow,
                CustomerId = 1
            });
            _dbContext.SaveChanges();

            _dbContext.Transactions.Add(new Transaction
            {
                Amount = 50,
                BankAccountId = 1,
                DateCreated = DateTime.UtcNow
            });
            _dbContext.Transactions.Add(new Transaction
            {
                Amount = -125,
                BankAccountId = 1,
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            // Act
            var transactionRepository = new TransactionRepository(_dbContext);
            var balance = transactionRepository.GetBalanceByBankAccountId(1).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(-75, balance);
        }
    }
}
