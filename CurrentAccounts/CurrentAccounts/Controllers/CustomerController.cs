using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CurrentAccounts.Core.Extensions;
using Microsoft.AspNetCore.Http;
using CurrentAccounts.Core.Interfaces.Services;

namespace CurrentAccounts.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get([Range(1, int.MaxValue, ErrorMessage = "Invalid customer id.")]int id)
        {
            try
            {
                return new ObjectResult(await _customerService.GetCustomer(id));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(Get)}-{nameof(CustomerController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
