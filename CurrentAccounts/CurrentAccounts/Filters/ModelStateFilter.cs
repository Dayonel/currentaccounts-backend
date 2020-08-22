using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CurrentAccounts.Filters
{
    public class ModelStateFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState.Values.First().Errors.First().ErrorMessage);
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
