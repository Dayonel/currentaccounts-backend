using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CurrentAccounts.Data.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly CurrentAccountsDbContext _dbContext;
        public CustomerRepository(CurrentAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<bool> Exists(int id)
        {
            return await _dbContext.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
    }
}
