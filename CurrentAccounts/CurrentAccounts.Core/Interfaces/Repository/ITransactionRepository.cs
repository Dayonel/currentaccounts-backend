using CurrentAccounts.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        Task<bool> Add(Transaction transaction);
        Task<IReadOnlyCollection<Transaction>> GetByBankAccountId(int bankAccountId);
        Task<decimal> GetBalanceByBankAccountId(int bankAccountId);
    }
}
