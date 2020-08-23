using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using CurrentAccounts.Core.Extensions;
using Microsoft.AspNetCore.Http;
using CurrentAccounts.Core.Interfaces.Repository.Base;
using CurrentAccounts.Core.Interfaces.Services;
using System.Threading.Tasks;
using CurrentAccounts.ViewModel.Request;

namespace CurrentAccounts.Controllers
{
    [ApiController]
    [Route("api/bankaccount")]
    public class BankAccountController
    {
        private readonly ILogger<BankAccountController> _logger;
        private readonly ITransactionScopedRepository _transactionScoped;
        private readonly IBankAccountService _bankAccountService;
        public BankAccountController(ILogger<BankAccountController> logger, ITransactionScopedRepository transactionScoped,
            IBankAccountService bankAccountService)
        {
            _logger = logger;
            _transactionScoped = transactionScoped;
            _bankAccountService = bankAccountService;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create(CreateBankAccountVM accountVM)
        {
            try
            {
                return new ObjectResult
                    (await _transactionScoped.ExecuteScoped(delegate { return _bankAccountService.Create(accountVM.CustomerID, accountVM.InitialCredit); }));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(Create)}-{nameof(BankAccountController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
