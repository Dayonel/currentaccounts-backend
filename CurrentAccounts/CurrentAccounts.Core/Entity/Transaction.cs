using CurrentAccounts.Core.Entity.Base;
using CurrentAccounts.Core.Interfaces;
using System;

namespace CurrentAccounts.Core.Entity
{
    public class Transaction : EntityBase, ICreated
    {
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}
