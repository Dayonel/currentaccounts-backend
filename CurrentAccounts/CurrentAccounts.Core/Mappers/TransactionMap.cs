using CurrentAccounts.Core.DTO;
using CurrentAccounts.Core.Entity;

namespace CurrentAccounts.Core.Mappers
{
    public static class TransactionMap
    {
        public static TransactionDTO Map(this Transaction transaction)
        {
            return transaction != null
                ?
                new TransactionDTO
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount
                }
                : null;
        }
    }
}
