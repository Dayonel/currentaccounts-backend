using System;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Repository.Base
{
    public interface ITransactionScopedRepository
    {
        Task<bool> ExecuteScoped(Func<Task<bool>> function);
    }
}
