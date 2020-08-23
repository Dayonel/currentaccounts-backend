using CurrentAccounts.Core.DTO;
using CurrentAccounts.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CurrentAccounts.Core.Mappers
{
    public static class BankAccountMap
    {
        public static BankAccountDTO Map(this BankAccount bankAccount, List<Transaction> transactions)
        {
            return bankAccount != null
                ?
                new BankAccountDTO
                {
                    Id = bankAccount.Id,
                    Balance = bankAccount.Balance,
                    Transactions = transactions.Select(t => t.Map()).ToList()
                }
                : null;
        }
    }
}
