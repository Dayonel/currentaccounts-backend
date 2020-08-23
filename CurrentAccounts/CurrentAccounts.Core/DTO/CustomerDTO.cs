using System.Collections.Generic;

namespace CurrentAccounts.Core.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<BankAccountDTO> BankAccounts { get; set; }
    }
}
