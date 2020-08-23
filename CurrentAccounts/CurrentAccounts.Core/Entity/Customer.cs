using CurrentAccounts.Core.Entity.Base;
using CurrentAccounts.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CurrentAccounts.Core.Entity
{
    public class Customer : EntityBase, ICreated
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual List<BankAccount> BankAccounts { get; set; }
    }
}
