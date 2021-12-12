using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace WebApplication3.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;
        public CustomActionFilterAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CustomActionFilterAttribute>();
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // starts before action execution
            _logger.LogInformation($"{context.ActionDescriptor.DisplayName} started at {DateTime.UtcNow}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // starts after action execution
            _logger.LogInformation($"{context.ActionDescriptor.DisplayName} ended at {DateTime.UtcNow}");
        }
    }
}
