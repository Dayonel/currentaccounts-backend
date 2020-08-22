using CurrentAccounts.Core.Entity.Base;
using CurrentAccounts.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CurrentAccounts.Core.Entity
{
    public class BankAccount : EntityBase, ICreated, IUpdated
    {
        public decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
