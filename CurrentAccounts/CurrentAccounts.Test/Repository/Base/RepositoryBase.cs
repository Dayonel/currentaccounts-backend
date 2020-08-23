using CurrentAccounts.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace CurrentAccounts.Test.Repository.Base
{
    public abstract class RepositoryBase : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        protected readonly CurrentAccountsDbContext _dbContext;
        protected RepositoryBase()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<CurrentAccountsDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            _dbContext = new CurrentAccountsDbContext(options);
            _dbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
