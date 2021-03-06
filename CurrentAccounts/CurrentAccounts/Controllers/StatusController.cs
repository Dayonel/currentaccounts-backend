﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using CurrentAccounts.Core.Extensions;

namespace CurrentAccounts.Controllers
{
    [ApiController]
    [Route("api/status")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class StatusController 
    {
        private readonly ILogger<StatusController> _logger;
        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult("OK");
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(Get)}-{nameof(StatusController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
