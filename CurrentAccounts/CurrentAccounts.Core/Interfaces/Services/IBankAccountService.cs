using CurrentAccounts.Core.Entity;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Services
{
    public interface IBankAccountService
    {
        Task<bool> Create(int customerId, decimal initialCredit);
        Task<bool> UpdateBalance(BankAccount bankAccount);
    }
}
