using CurrentAccounts.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Repository
{
    public interface IBankAccountRepository
    {
        Task<bool> Add(BankAccount bankAccount);
        Task<IReadOnlyCollection<BankAccount>> GetByCustomerId(int customerId);
        Task<bool> Update(BankAccount bankAccount);
    }
}
