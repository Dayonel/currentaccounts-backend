using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Services;
using CurrentAccounts.Data.Repository;
using CurrentAccounts.Test.Repository.Base;
using System;
using System.Linq;
using Xunit;

namespace CurrentAccounts.Test.Service
{
    public class CustomerServiceTests : RepositoryBase
    {
        [Fact]
        public void CustomerService_Customer_Doesnt_Exist()
        {
            // Arrange
            var customerService = new CustomerService(new CustomerRepository(_dbContext), 
                new BankAccountRepository(_dbContext), 
                new TransactionRepository(_dbContext));

            // Act
            var customer = customerService.GetCustomer(1).GetAwaiter().GetResult();

            // Assert
            Assert.Null(customer);
        }

        [Fact]
        public void CustomerService_Customer_WithBankAccount()
        {
            // Arrange
            var customerService = new CustomerService(new CustomerRepository(_dbContext),
                new BankAccountRepository(_dbContext),
                new TransactionRepository(_dbContext));

            var name = Guid.NewGuid().ToString();
            var surname = Guid.NewGuid().ToString();
            _dbContext.Customers.Add(new Customer
            {
                Name = name,
                Surname = surname,
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
            var customer = customerService.GetCustomer(1).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(name, customer.Name);
            Assert.Equal(surname, customer.Surname);
            Assert.True(1 == customer.BankAccounts.Count());
        }

        [Fact]
        public void CustomerService_Customer_WithBankAccountAndTransactions()
        {
            // Arrange
            var customerService = new CustomerService(new CustomerRepository(_dbContext),
                new BankAccountRepository(_dbContext),
                new TransactionRepository(_dbContext));

            var name = Guid.NewGuid().ToString();
            var surname = Guid.NewGuid().ToString();
            _dbContext.Customers.Add(new Customer
            {
                Name = name,
                Surname = surname,
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            var bankAccountRepository = new BankAccountRepository(_dbContext);
            bankAccountRepository.Add(new BankAccount
            {
                CustomerId = 1
            }).GetAwaiter().GetResult();
            _dbContext.SaveChanges();

            _dbContext.Transactions.Add(new Transaction
            {
                Amount = 50,
                BankAccountId = 1,
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            // Act
            var customer = customerService.GetCustomer(1).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(name, customer.Name);
            Assert.Equal(surname, customer.Surname);
            Assert.True(1 == customer.BankAccounts.Count());
            Assert.True(1 == customer.BankAccounts.First().Transactions.Count());
        }
    }
}
