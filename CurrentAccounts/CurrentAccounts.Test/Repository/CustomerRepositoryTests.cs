using CurrentAccounts.Core.Entity;
using CurrentAccounts.Data.Repository;
using CurrentAccounts.Test.Repository.Base;
using System;
using Xunit;

namespace CurrentAccounts.Test.Repository
{
    public class CustomerRepositoryTests : RepositoryBase
    {
        [Fact]
        public void Customer_Exists()
        {
            // Arrange
            _dbContext.Customers.Add(new Customer
            {
                Name = "GetByIdTest",
                Surname = "TestSurname",
                DateCreated = DateTime.UtcNow
            });
            _dbContext.SaveChanges();

            // Act
            var customerRepository = new CustomerRepository(_dbContext);
            var customer = customerRepository.GetById(1).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
            Assert.Equal("GetByIdTest", customer.Name);
            Assert.Equal("TestSurname", customer.Surname);
        }
    }
}
