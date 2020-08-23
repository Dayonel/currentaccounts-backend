using System.Collections.Generic;

namespace CurrentAccounts.Core.DTO
{
    public class BankAccountDTO
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionDTO> Transactions { get; set; }
    }
}
