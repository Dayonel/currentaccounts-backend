using CurrentAccounts.Core.DTO;
using CurrentAccounts.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CurrentAccounts.Core.Mappers
{
    public static class CustomerMap
    {
        public static CustomerDTO Map(this Customer customer, List<BankAccount> bankAccounts)
        {
            return customer != null
                ?
                new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    BankAccounts = bankAccounts.Select(b => b.Map(b.Transactions)).ToList()
                }
                : null;
        }
    }
}
