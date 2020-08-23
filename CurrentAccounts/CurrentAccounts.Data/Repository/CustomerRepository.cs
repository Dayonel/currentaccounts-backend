using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Interfaces.Repository;
using System.Threading.Tasks;

namespace CurrentAccounts.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CurrentAccountsDbContext _dbContext;
        public CustomerRepository(CurrentAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
    }
}
