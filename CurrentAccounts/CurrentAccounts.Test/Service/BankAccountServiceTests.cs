using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Services;
using CurrentAccounts.Data.Repository;
using CurrentAccounts.Test.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CurrentAccounts.Test.Service
{
    public class BankAccountServiceTests : RepositoryBase
    {
        [Fact]
        public void BankAccountService_Create_Without_InitialCredit()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            var bankAccountService = new BankAccountService(new BankAccountRepository(_dbContext), new TransactionRepository(_dbContext));

            // Act
            var result = bankAccountService.Create(1, 0).GetAwaiter().GetResult();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BankAccountService_Create_Without_Customer_Fails()
        {
            Assert.Throws<DbUpdateException>(CreateBankAccountException);
        }

        private void CreateBankAccountException()
        {
            var bankAccountService = new BankAccountService(new BankAccountRepository(_dbContext), new TransactionRepository(_dbContext));
            bankAccountService.Create(1, 0).GetAwaiter().GetResult();
        }

        [Fact]
        public void BankAccountService_Create_With_InitialCredit()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            var bankAccountService = new BankAccountService(new BankAccountRepository(_dbContext), new TransactionRepository(_dbContext));

            // Act
            var result = bankAccountService.Create(1, 50).GetAwaiter().GetResult();

            // Assert
            Assert.True(result);
            Assert.Equal(50, _dbContext.BankAccounts.FirstOrDefault().Balance);
            Assert.Equal(50, _dbContext.BankAccounts.FirstOrDefault().Transactions.FirstOrDefault()?.Amount);
        }
    }
}
