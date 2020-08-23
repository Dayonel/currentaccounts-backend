using CurrentAccounts.Core.DTO;
using CurrentAccounts.Core.Interfaces.Repository;
using CurrentAccounts.Core.Interfaces.Services;
using CurrentAccounts.Core.Mappers;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransactionRepository _transactionRepository;
        public CustomerService(ICustomerRepository customerRepository, IBankAccountRepository bankAccountRepository,
            ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _bankAccountRepository = bankAccountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<CustomerDTO> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetById(id);
            var bankAccounts = await _bankAccountRepository.GetByCustomerId(id);

            foreach (var account in bankAccounts)
                account.Transactions = (await _transactionRepository.GetByBankAccountId(account.Id)).ToList();

            return customer.Map(bankAccounts.ToList());
        }
    }
}
