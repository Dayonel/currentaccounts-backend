using CurrentAccounts.Data;
using CurrentAccounts.Core.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrentAccounts.Infrastructure.HostedServices.Services
{
    public class DbDataSeeder : IHostedService
    {
        private readonly IServiceProvider _provider;
        public DbDataSeeder(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await SeedCustomers();
            await SeedBankAccounts();
            await SeedTransactions();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        #region Customers
        private async Task SeedCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer
                {
                    Name = "John",
                    Surname = "Smith",
                    DateCreated = DateTime.UtcNow
                },
                new Customer
                {
                    Name = "Robert",
                    Surname = "Williams",
                    DateCreated = DateTime.UtcNow
                },
                new Customer
                {
                    Name = "Michael",
                    Surname = "Brown",
                    DateCreated = DateTime.UtcNow
                },
                new Customer
                {
                    Name = "William",
                    Surname = "Jones",
                    DateCreated = DateTime.UtcNow
                },
                new Customer
                {
                    Name = "David",
                    Surname = "Miller",
                    DateCreated = DateTime.UtcNow
                }
            };

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<CurrentAccountsDbContext>())
                {
                    _dbContext.Customers.AddRange(customers);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        #endregion

        #region BankAccounts
        private async Task SeedBankAccounts()
        {
            var bankAccounts = new List<BankAccount>()
            {
                new BankAccount
                {
                    Balance = 10,
                    CustomerId = 2,
                    DateCreated = DateTime.UtcNow
                },
                new BankAccount
                {
                    Balance = -7.896M,
                    CustomerId = 3,
                    DateCreated = DateTime.UtcNow
                },
                new BankAccount
                {
                    Balance = 2596.21M,
                    CustomerId = 4,
                    DateCreated = DateTime.UtcNow
                },
                new BankAccount
                {
                    Balance = 0,
                    CustomerId = 5,
                    DateCreated = DateTime.UtcNow
                }
            };

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<CurrentAccountsDbContext>())
                {
                    _dbContext.BankAccounts.AddRange(bankAccounts);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        #endregion

        #region Transactions
        private async Task SeedTransactions()
        {
            var transactions = new List<Transaction>()
            {
                new Transaction
                {
                    Amount = 10,
                    BankAccountId = 1,
                    DateCreated = DateTime.UtcNow
                },
                new Transaction
                {
                    Amount = -5,
                    BankAccountId = 2,
                    DateCreated = DateTime.UtcNow
                },
                new Transaction
                {
                    Amount = -2.896M,
                    BankAccountId = 2,
                    DateCreated = DateTime.UtcNow
                },
                new Transaction
                {
                    Amount = 588,
                    BankAccountId = 3,
                    DateCreated = DateTime.UtcNow
                },
                new Transaction
                {
                    Amount = -25,
                    BankAccountId = 3,
                    DateCreated = DateTime.UtcNow
                },
                new Transaction
                {
                    Amount = 1745,
                    BankAccountId = 3,
                    DateCreated = DateTime.UtcNow
                },
                new Transaction
                {
                    Amount = 288.21M,
                    BankAccountId = 3,
                    DateCreated = DateTime.UtcNow
                },
            };

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<CurrentAccountsDbContext>())
                {
                    _dbContext.Transactions.AddRange(transactions);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        #endregion
    }
}
