using CurrentAccounts.Core.Entity;
using CurrentAccounts.Data.Repository;
using CurrentAccounts.Test.Repository.Base;
using System;
using System.Linq;
using Xunit;

namespace CurrentAccounts.Test.Repository
{
    public class BankAccountRepositoryTest : RepositoryBase
    {
        [Fact]
        public void AddBankAccount()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            var bankAccountRepository = new BankAccountRepository(_dbContext);
            bankAccountRepository.Add(new BankAccount
            {
                CustomerId = 1
            }).GetAwaiter().GetResult();
            _dbContext.SaveChanges();

            // Act
            var bankAccount = _dbContext.BankAccounts.First(b => b.CustomerId == 1);

            // Assert
            Assert.NotNull(bankAccount);
            Assert.Equal(0, bankAccount.Balance);
        }

        [Fact]
        public void BankAccount_Doesnt_Exist()
        {
            // Arrange

            // Act
            var bankAccount = _dbContext.BankAccounts.FirstOrDefault(b => b.CustomerId == 1);

            // Assert
            Assert.Null(bankAccount);
        }

        [Fact]
        public void BankAccount_GetByCustomerId()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            var bankAccountRepository = new BankAccountRepository(_dbContext);
            _dbContext.BankAccounts.Add(new BankAccount
            {
                CustomerId = 1
            });
            _dbContext.SaveChanges();

            // Act
            var bankAccount = bankAccountRepository.GetByCustomerId(1);

            // Assert
            Assert.NotNull(bankAccount);
        }

        [Fact]
        public void BankAccount_Update()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = Guid.NewGuid().ToString(),
                Surname = Guid.NewGuid().ToString(),
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            var bankAccountRepository = new BankAccountRepository(_dbContext);
            _dbContext.BankAccounts.Add(new BankAccount
            {
                CustomerId = 1
            });
            _dbContext.SaveChanges();

            var bankAccount = _dbContext.BankAccounts.First(b => b.CustomerId == 1);

            // Act
            bankAccount.Balance = 555;
            bankAccountRepository.Update(bankAccount).GetAwaiter().GetResult();
            var updatedAccount = _dbContext.BankAccounts.First();

            // Assert
            Assert.NotNull(updatedAccount);
            Assert.Equal(555, updatedAccount.Balance);
        }
    }
}
