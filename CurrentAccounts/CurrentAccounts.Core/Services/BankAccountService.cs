using CurrentAccounts.Core.Entity;
using CurrentAccounts.Core.Interfaces.Repository;
using CurrentAccounts.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransactionRepository _transactionRepository;
        public BankAccountService(ICustomerRepository customerRepository, IBankAccountRepository bankAccountRepository,
            ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _bankAccountRepository = bankAccountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> Create(int customerId, decimal initialCredit)
        {
            var result = false;

            if (!await _customerRepository.Exists(customerId))
                return result;

            var bankAccount = new BankAccount { CustomerId = customerId };
            result = await _bankAccountRepository.Add(bankAccount);

            if (initialCredit != 0)
            {
                result &= await _transactionRepository.Add(new Transaction { BankAccountId = bankAccount.Id, Amount = initialCredit });
                result &= await UpdateBalance(bankAccount);
            }

            return result;
        }

        public async Task<bool> UpdateBalance(BankAccount bankAccount)
        {
            var balance = await _transactionRepository.GetBalanceByBankAccountId(bankAccount.Id);

            bankAccount.Balance = balance;

            return await _bankAccountRepository.Update(bankAccount);
        }
    }
}
