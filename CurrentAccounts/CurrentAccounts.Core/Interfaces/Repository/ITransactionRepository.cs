using CurrentAccounts.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        Task<int> Add(Transaction transaction);
        Task<IReadOnlyCollection<Transaction>> GetByBankAccountId(int bankAccountId);
    }
}
